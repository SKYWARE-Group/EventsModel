namespace Skyware.Lis.EventsModel.Catalog;

/// <summary>
/// Change desription in catalog data.
/// </summary>
public class PropertyChange
{

    /// <summary>
    /// Name of the column in the database table where the property is stored, e.g. "Name", "IsDerived", etc.
    /// </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// Name of the property in LIS Model library that has been changed, e.g. "Name", "IsDerived", etc.
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// Old value of the property before the change.
    /// </summary>
    /// <remarks>
    /// For non-string types, consider serializing the value to a string format as follows:
    /// <list type="bullet">
    ///   <item><term>int, byte, short, long</term><description>"42"</description></item>
    ///   <item><term>decimal, money</term><description>"3.14" (invariant culture, up to last significant digit)</description></item>
    ///   <item><term>boolean, bit</term><description>"true" or "false" (case-insensitive)</description></item>
    /// </list>
    /// Same applies to <see cref="NewValue"/> property.
    /// </remarks>
    public string OldValue { get; set; }

    /// <summary>
    /// New value of the property after the change.
    /// </summary>
    /// <remarks>
    /// See <see cref="OldValue"/> for serialization recommendations for non-string types.
    /// </remarks>
    public string NewValue { get; set; }

}
