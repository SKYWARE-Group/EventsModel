using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// Reads the model's embedded compiler-generated XML documentation and renders it as plain text.
/// </summary>
internal sealed class ModelDocumentation
{
    /// <summary>
    /// Documentation entries indexed by their compiler-generated member IDs.
    /// </summary>
    private readonly Dictionary<string, XElement> members;

    /// <summary>
    /// Loads and indexes the embedded model documentation.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// The embedded documentation resource is missing.
    /// </exception>
    public ModelDocumentation()
    {
        using var stream = typeof(ModelDocumentation).Assembly.GetManifestResourceStream(
            "Skyware.Lis.EventsModel.Meta.ModelDocumentation.xml")
            ?? throw new InvalidOperationException("Embedded model XML documentation is missing.");
        members = XDocument.Load(stream).Descendants("member")
            .ToDictionary(x => (string)x.Attribute("name")!, StringComparer.Ordinal);
    }

    /// <summary>
    /// Renders the summary and remarks for a model type, field, or property, resolving supported inheritdoc references.
    /// </summary>
    /// <param name="member">
    /// The reflected model member whose documentation is requested.
    /// </param>
    /// <returns>
    /// The rendered description, or an empty string when no supported documentation is available.
    /// Summary and remarks are separated by a blank line.
    /// </returns>
    public string Describe(MemberInfo member)
    {
        var prefix = member is Type ? "T:" : member is FieldInfo ? "F:" : "P:";
        var id = prefix + (member is Type t ? t.FullName : member.DeclaringType!.FullName + "." + member.Name);
        if (!members.TryGetValue(id, out var doc)) return "";
        var parts = new[] { doc.Element("summary"), doc.Element("remarks") }
            .Where(x => x is not null).Select(x => Render(x!)).Where(x => x.Length > 0).ToArray();
        if (parts.Length > 0) return string.Join("\n\n", parts);
        if (doc.Element("inheritdoc") is { } inherit)
        {
            var reference = (string?)inherit.Attribute("cref");
            if (reference is not null && members.TryGetValue(reference, out var inherited))
                return string.Join("\n\n", new[] { inherited.Element("summary"), inherited.Element("remarks") }
                    .Where(x => x is not null).Select(x => Render(x!)));
            var baseType = (member as Type)?.BaseType ?? member.DeclaringType?.BaseType;
            if (baseType is not null)
            {
                MemberInfo? baseMember = member is Type ? baseType : baseType.GetProperty(member.Name);
                if (baseMember is not null) return Describe(baseMember);
            }
        }
        return "";
    }

    /// <summary>
    /// Converts an XML documentation element to plain text, rendering references and normalizing whitespace.
    /// </summary>
    /// <param name="element">
    /// The documentation element to render.
    /// </param>
    /// <returns>
    /// The rendered text with surrounding whitespace removed.
    /// </returns>
    private static string Render(XElement element)
    {
        string Walk(XNode node) => node switch
        {
            XText text => text.Value,
            XElement e when e.Name.LocalName is "see" or "seealso" => e.Value.Length > 0 ? e.Value
                : (string?)e.Attribute("langword") ?? Reference((string?)e.Attribute("cref"))
                    ?? (string?)e.Attribute("href") ?? "",
            XElement e when e.Name.LocalName is "paramref" or "typeparamref" => (string?)e.Attribute("name") ?? "",
            XElement e => " " + string.Concat(e.Nodes().Select(Walk)) + " ",
            _ => ""
        };
        return Regex.Replace(string.Concat(element.Nodes().Select(Walk)), @"\s+", " ").Trim();
    }

    /// <summary>
    /// Converts a compiler-generated reference ID to a readable name relative to the model namespace.
    /// </summary>
    /// <param name="value">
    /// The reference ID, or null when no reference is present.
    /// </param>
    /// <returns>
    /// The readable reference name, or null when the input is null.
    /// </returns>
    private static string? Reference(string? value) => value is null ? null
        : value[(value.IndexOf(':') + 1)..].Replace("Skyware.Lis.EventsModel.", "", StringComparison.Ordinal);
}
