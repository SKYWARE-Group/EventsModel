# EventsModel.Meta

`Skyware.Lis.EventsModel.Meta` provides documented JSON Schema 2020-12 documents,
message discovery, recognition and parsing for `Skyware.Lis.EventsModel`.
It targets .NET 8, 9 and 10 and is independent of any MCP server SDK.

## Usage

```csharp
using Skyware.Lis.EventsModel.Meta;

var catalog = new MessageCatalog(); // Reuse across requests.
var types = catalog.ListMessageTypes();
var description = catalog.DescribeMessage("Instruments.ResultApproval");
var schemaJson = description.Schema.ToJsonString();

var explanation = catalog.ExplainMessage("""{"ShipmentId":42,"IsSent":true}""");
if (explanation.Status == MessageMatchStatus.Matched)
{
    var message = catalog.ParseMessage(explanation.Message!.Value.GetRawText());
}

// When the transport supplies a reliable message type:
var approved = catalog.ParseMessage("""{"Data":null}""", "Instruments.ResultApproval");

// Supporting objects and enums can also be described independently.
var resultSchema = catalog.GetSchema<Skyware.Lis.EventsModel.Results.TestResult>();
```

| MCP tool | Library call |
| --- | --- |
| `list_message_types()` | `catalog.ListMessageTypes()` |
| `describe_message(type)` | `catalog.DescribeMessage(type)` |
| `explain_message(json)` | `catalog.ExplainMessage(json)` |

The returned records, schemas and payloads can be serialized with `System.Text.Json`.
Match statuses serialize as readable strings. An agent consuming the tool responses
does not need access to the model assembly or source code.

## Schemas and documentation

- Compiler-produced model XML documentation is embedded in the Meta assembly.
  NuGet consumers need no source files or sidecar XML documentation.
- Schemas follow `System.Text.Json` metadata: inheritance, nested objects,
  collections, nullable values, ignored and read-only properties. `summary` and
  `remarks` become `description`; XML references are rendered as text.
  Descriptions retain their source language.
- Enum members are documented in `x-enumDescriptions`, preserving distinctions
  such as technical versus medical validation. Enums retain their numeric wire format.
- Examples are deterministic **synthetic structural examples**, not real clinical
  data, medical guidance or complete production events.
- Schemas are standalone, using local references where necessary. Returned
  documents are copies; editing them does not alter the catalog.

## Wire format and recognition

Names default to **PascalCase**, matching the model's current JSON contract.
CamelCase can be selected explicitly:

```csharp
var catalog = new MessageCatalog(new MessageCatalogOptions
{
    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
});
```

Names are case-sensitive. Unknown properties, including nested ones, are rejected
(`additionalProperties: false` for object contracts). This strict recognition
policy avoids misidentification caused by silently dropping fields. Future
producer fields can therefore produce `NoMatch` until the consumer updates its model.

Fields are required only when required by the serialization contract. No business
requirements are invented: `{}` and messages with only common fields are ambiguous.
A unique match means compatibility with this catalog, not proof of producer intent.
`Instruments.Result` and `Instruments.ResultApproval` have identical shapes, so both
are returned without an external type or discriminator. Candidates are never ranked.

Recognition returns `Matched`, `Ambiguous`, `NoMatch`, `InvalidJson`,
`InvalidMessage`, or `UnknownDiscriminator`. It includes the original parsed JSON
and documentation for **all** compatible candidates. When no type matches, errors
identify the candidate and location. Schema errors use JSON Pointers; deserialization
errors use System.Text.Json paths.

`ParseMessage` validates before deserializing and throws `MessageParseException`
containing the explanation if it cannot select one valid type. Explicit type names
accept a relative model ID, full CLR name or unambiguous simple name. Arbitrary CLR
types supplied by input are never loaded.

JSON Schema `format` values remain annotations. Recognition also runs the .NET
deserializer to check actual CLR constraints (integer ranges, dates, etc.). This
accepts offset-free timestamps serialized from `DateTimeKind.Unspecified` and
rejects invalid dates. It does not validate clinical or business rules.

Input defaults: 1 MiB UTF-8 and 64 nesting levels, configurable through
`MaxMessageBytes` and `MaxDepth`. Duplicate property names at any level are rejected.

## Optional discriminator

The model's current `JsonDerivedType` attributes do not declare discriminator
values. Configure a transport convention explicitly when producers supply one:

```csharp
var catalog = new MessageCatalog(new MessageCatalogOptions
{
    DiscriminatorPropertyName = "$type",
    DiscriminatorMappings = new Dictionary<string, string>
    {
        ["result"] = "Instruments.Result",
        ["approved-result"] = "Instruments.ResultApproval"
    }
});
var message = catalog.ParseMessage("""{"$type":"approved-result","Data":null}""");
```

Only registered string values are accepted. The discriminator appears in the
schema and original JSON, and is removed only for CLR deserialization. Unknown
values never fall back to guessing. A known discriminator still requires a valid
payload; conflicts with an explicitly requested type are rejected. When absent,
structural matching is used. These options do not modify producer serialization.

## Existing model details

The schemas describe the actual wire contract, including these existing details:

- `Results.ResultsSet.Results` is non-public and is not serialized.
- Concrete `DefaultAddress` overrides are serialized despite `[JsonIgnore]` on
  the abstract base property. They are marked read-only and also appear in
  discovery metadata. Their input values do not select a type.
- Missing CLR properties retain their initializers (IDs, timestamps, defaults)
  when parsed. The original JSON in `ExplainMessage` is never filled in or changed.

## Build and test

```sh
dotnet test tests/EventsModel.Meta.Tests/EventsModel.Meta.Tests.csproj -c Release -p:GeneratePackageOnBuild=false
dotnet pack src/EventsModel.Meta/EventsModel.Meta.csproj -c Release -p:GeneratePackageOnBuild=false -o artifacts
```

The package depends on `Skyware.Lis.EventsModel` at its project-reference version.
The existing publishing workflow does not publish the new Meta package automatically.

References: [System.Text.Json schema exporter](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/extract-schema),
[JsonSchema.Net](https://docs.json-everything.net/schema/basics/).
