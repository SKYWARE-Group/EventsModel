using System.Text.Json;
using System.Text.Json.Nodes;
using Json.Schema;
using Skyware.Lis.EventsModel;
using Skyware.Lis.EventsModel.Meta;
using Skyware.Lis.EventsModel.Visits;
using Skyware.Lis.EventsModel.Results;
using InstrumentResult = Skyware.Lis.EventsModel.Instruments.Result;

namespace EventsModel.Meta.Tests;

public class MessageCatalogTests
{
    private readonly MessageCatalog catalog = new();

    [Fact]
    public void DiscoversAllConcreteMessagesAndIncludesDescriptionsAndAddresses()
    {
        var types = catalog.ListMessageTypes();
        var expected = typeof(BaseMessage).Assembly.GetExportedTypes()
            .Where(t => !t.IsAbstract && typeof(BaseMessage).IsAssignableFrom(t)).Select(t => t.FullName).Order().ToArray();
        Assert.Equal(expected, types.Select(t => t.ClrType).Order().ToArray());
        Assert.Equal(15, types.Count);
        Assert.All(types, t => { Assert.NotEmpty(t.Description); Assert.StartsWith("topic://", t.DefaultAddress); });
    }

    [Fact]
    public void SchemasContainInheritedAndNestedDocumentationAndRemarks()
    {
        var schema = catalog.DescribeMessage("Visits.Sale").Schema;
        var properties = schema["properties"]!.AsObject();
        Assert.Equal("https://json-schema.org/draft/2020-12/schema", schema["$schema"]!.GetValue<string>());
        Assert.Contains("GUID", properties["Id"]!["description"]!.GetValue<string>());
        Assert.Contains("does not report funds", properties["Funding"]!["description"]!.GetValue<string>());
        Assert.Contains("has been removed", properties["Diagnoses"]!["description"]!.GetValue<string>());
        Assert.Contains("GivenName", schema.ToJsonString());
        Assert.Contains("First (given) name", schema.ToJsonString());
        Assert.DoesNotContain("<see", schema.ToJsonString());
        // Overrides do not inherit JsonIgnore from BaseMessage in the current model.
        Assert.True(properties["DefaultAddress"]!["readOnly"]!.GetValue<bool>());
        Assert.True(properties["LocalEventTime"]!["readOnly"]!.GetValue<bool>());
        Assert.Contains("null", properties["Funding"]!.ToJsonString());
        Assert.False(schema["additionalProperties"]!.GetValue<bool>());
    }

    [Fact]
    public void IncludesEnumValueSemantics()
    {
        var schema = catalog.GetSchema<TestResult>();
        var descriptions = schema["properties"]!["Status"]!["x-enumDescriptions"]!.AsArray();
        var preliminary = descriptions.Single(x => x!["name"]!.GetValue<string>() == "Preliminary")!;
        Assert.Equal(2, preliminary["value"]!.GetValue<int>());
        Assert.Contains("not ready for reporting", preliminary["description"]!.GetValue<string>());
    }

    [Fact]
    public void CanExportEveryPublicModelClassAndEnum()
    {
        foreach (var type in typeof(BaseMessage).Assembly.GetExportedTypes().Where(t => t.IsClass || t.IsEnum))
            Assert.NotNull(catalog.GetSchema(type)["$schema"]);
    }

    [Fact]
    public void SchemaFollowsActualSerializationIncludingNonPublicAndIgnoredMembers()
    {
        var schema = catalog.GetSchema<ResultsSet>();
        Assert.Null(schema["properties"]!["Results"]); // Currently private in the model: do not invent wire fields.
        foreach (var info in catalog.ListMessageTypes())
        {
            var type = typeof(BaseMessage).Assembly.GetType(info.ClrType)!;
            var message = (BaseMessage)Activator.CreateInstance(type)!;
            var json = JsonSerializer.Serialize<BaseMessage>(message);
            using var serialized = JsonDocument.Parse(json);
            Assert.Equal(serialized.RootElement.EnumerateObject().Select(p => p.Name).Order(),
                catalog.DescribeMessage(info.Type).Schema["properties"]!.AsObject().Select(p => p.Key).Order());
            Assert.IsType(type, catalog.ParseMessage(json, info.Type));
        }
    }

    [Fact]
    public void EverySyntheticExampleIsDeterministicSchemaValidAndParseable()
    {
        foreach (var info in catalog.ListMessageTypes())
        {
            var description = catalog.DescribeMessage(info.Type);
            var example = Assert.Single(description.Examples);
            Assert.Contains("Synthetic", example.Description);
            using var json = JsonDocument.Parse(example.Value.ToJsonString());
            var validator = JsonSchema.FromText(description.Schema.ToJsonString(), new BuildOptions { SchemaRegistry = new() });
            Assert.True(validator.Evaluate(json.RootElement, new EvaluationOptions { RequireFormatValidation = true }).IsValid, info.Type);
            Assert.Equal(info.ClrType, catalog.ParseMessage(example.Value.ToJsonString(), info.Type).GetType().FullName);
            Assert.Equal(example.Value.ToJsonString(), catalog.DescribeMessage(info.Type).Examples[0].Value.ToJsonString());
        }
    }

    [Fact]
    public void RecognizesUniqueShapeAndPreservesOriginalPayload()
    {
        const string json = """{"ShipmentId":42,"IsSent":true,"Sender":{"Id":7}}""";
        var result = catalog.ExplainMessage(json);
        Assert.Equal(MessageMatchStatus.Matched, result.Status);
        Assert.Equal("SampleTracking.SampleShipment", Assert.Single(result.Candidates).MessageType.Type);
        Assert.Equal(42, result.Message!.Value.GetProperty("ShipmentId").GetInt32());
        var parsed = Assert.IsType<Skyware.Lis.EventsModel.SampleTracking.SampleShipment>(catalog.ParseMessage(json));
        Assert.Equal(42, parsed.ShipmentId);
    }

    [Fact]
    public void IdenticalResultAndApprovalShapesRemainAmbiguous()
    {
        var json = catalog.DescribeMessage("Instruments.Result").Examples[0].Value.ToJsonString();
        var result = catalog.ExplainMessage(json);
        Assert.Equal(MessageMatchStatus.Ambiguous, result.Status);
        Assert.Equal(new[] { "Instruments.Result", "Instruments.ResultApproval" }, result.Candidates.Select(c => c.MessageType.Type));
        var error = Assert.Throws<MessageParseException>(() => catalog.ParseMessage(json));
        Assert.Equal(MessageMatchStatus.Ambiguous, error.Explanation.Status);
        Assert.IsType<InstrumentResult>(catalog.ParseMessage(json, "Instruments.Result"));
    }

    [Theory]
    [InlineData("{}")]
    [InlineData("{\"Id\":\"shared\"}")]
    public void SparseMessagesAreNotGuessed(string json)
    {
        var result = catalog.ExplainMessage(json);
        Assert.Equal(MessageMatchStatus.Ambiguous, result.Status);
        Assert.Equal(15, result.Candidates.Count);
    }

    [Theory]
    [InlineData("{\"ShipmentId\":\"not-a-number\"}")]
    [InlineData("{\"ShipmentId\":1.5}")]
    [InlineData("{\"ShipmentId\":9999999999999999999}")]
    [InlineData("{\"ShipmentId\":1,\"Sent\":\"not-a-date\"}")]
    [InlineData("{\"ShipmentId\":1,\"Sender\":{\"Id\":\"wrong\"}}")]
    [InlineData("{\"unknown\":1}")]
    [InlineData("{\"shipmentId\":1}")]
    public void RejectsTypeMismatchesUnknownFieldsAndClrOverflow(string json)
    {
        var result = catalog.ExplainMessage(json);
        Assert.Equal(MessageMatchStatus.NoMatch, result.Status);
        Assert.NotEmpty(result.Errors);
        Assert.Empty(result.Candidates);
    }

    [Theory]
    [InlineData("not JSON")]
    [InlineData("{\"Id\":1,\"Id\":2}")]
    [InlineData("{\"Sender\":{\"Id\":1,\"Id\":2}}")]
    [InlineData("{\"Samples\":[{\"Id\":1,\"Id\":2}]}")]
    public void RejectsMalformedOrDuplicateJson(string json) =>
        Assert.Equal(MessageMatchStatus.InvalidJson, catalog.ExplainMessage(json).Status);

    [Theory]
    [InlineData("null")]
    [InlineData("[]")]
    [InlineData("42")]
    public void RequiresTopLevelObject(string json) =>
        Assert.Equal(MessageMatchStatus.InvalidMessage, catalog.ExplainMessage(json).Status);

    [Fact]
    public void RespectsPayloadAndDepthLimits()
    {
        var limited = new MessageCatalog(new() { MaxMessageBytes = 20, MaxDepth = 2 });
        Assert.Equal(MessageMatchStatus.InvalidJson, limited.ExplainMessage("{\"Id\":\"" + new string('я', 10) + "\"}").Status);
        Assert.Equal(MessageMatchStatus.InvalidJson, limited.ExplainMessage("{\"a\":{\"b\":{}}}").Status);
    }

    [Fact]
    public void OptionalDiscriminatorSelectsOnlyRegisteredTypesAndStillValidates()
    {
        var configured = DiscriminatedCatalog();
        var result = configured.ExplainMessage("""{"$type":"result","Data":null}""");
        Assert.Equal(MessageMatchStatus.Matched, result.Status);
        Assert.Equal("Instruments.Result", Assert.Single(result.Candidates).MessageType.Type);
        Assert.IsType<InstrumentResult>(configured.ParseMessage("""{"$type":"result","Data":null}"""));
        Assert.Equal(MessageMatchStatus.UnknownDiscriminator, configured.ExplainMessage("""{"$type":"System.IO.File"}""").Status);
        Assert.Equal(MessageMatchStatus.UnknownDiscriminator, configured.ExplainMessage("""{"$type":42}""").Status);
        Assert.Equal(MessageMatchStatus.InvalidMessage, configured.ExplainMessage("""{"$type":"result","Data":42}""").Status);
        Assert.Equal(MessageMatchStatus.Ambiguous, configured.ExplainMessage("{}").Status);
        Assert.Throws<MessageParseException>(() => configured.ParseMessage("""{"$type":"result"}""", "Instruments.Query"));
        var description = configured.DescribeMessage("Instruments.Result");
        Assert.Equal("result", description.Schema["properties"]!["$type"]!["enum"]![0]!.GetValue<string>());
        Assert.IsType<InstrumentResult>(configured.ParseMessage(description.Examples[0].Value.ToJsonString()));
    }

    [Fact]
    public void CamelCaseIsExplicitAndConsistentAcrossSchemasAndParsing()
    {
        var camel = new MessageCatalog(new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        Assert.NotNull(camel.DescribeMessage("Visits.Sale").Schema["properties"]!["saleId"]);
        Assert.Equal(MessageMatchStatus.Matched, camel.ExplainMessage("""{"shipmentId":1}""").Status);
        Assert.Equal(MessageMatchStatus.NoMatch, camel.ExplainMessage("""{"ShipmentId":1}""").Status);
    }

    [Fact]
    public void ReturnedDocumentsCannotMutateCachedSchemas()
    {
        var description = catalog.DescribeMessage("Visits.Sale");
        description.Schema["properties"] = new JsonObject();
        description.Examples[0].Value["SaleId"] = 999;
        Assert.NotNull(catalog.DescribeMessage("Visits.Sale").Schema["properties"]!["SaleId"]);
        Assert.Equal(0, catalog.DescribeMessage("Visits.Sale").Examples[0].Value["SaleId"]!.GetValue<int>());
    }

    [Fact]
    public void OnlyKnownModelTypesAreAccepted()
    {
        Assert.Throws<ArgumentException>(() => catalog.GetSchema(typeof(string)));
        Assert.Throws<ArgumentException>(() => catalog.DescribeMessage("System.IO.File"));
        Assert.Equal("Visits.Sale", catalog.DescribeMessage(typeof(Sale).FullName!).MessageType.Type);
        Assert.Equal("Visits.Sale", catalog.DescribeMessage("Sale").MessageType.Type);
        Assert.Throws<ArgumentException>(() => new MessageCatalog(new() { DiscriminatorPropertyName = "Id" }));
        Assert.Throws<ArgumentException>(() => new MessageCatalog(new() { DiscriminatorMappings = new Dictionary<string, string> { ["x"] = "Sale" } }));
    }

    [Fact]
    public void DocumentationIsEmbeddedAndCourierDescriptionSurvivesCompilation()
    {
        Assert.Contains("Skyware.Lis.EventsModel.Meta.ModelDocumentation.xml", typeof(MessageCatalog).Assembly.GetManifestResourceNames());
        var schema = catalog.DescribeMessage("SampleTracking.SampleShipment").Schema;
        Assert.Contains("courier", schema["properties"]!["CourierId"]!["description"]!.GetValue<string>());
    }

    [Fact]
    public void HandlesNestedArraysAndReportsTheirErrorPaths()
    {
        var result = catalog.ExplainMessage("""{"ShipmentId":1,"Samples":[{"Id":"wrong"}]}""");
        Assert.Equal(MessageMatchStatus.NoMatch, result.Status);
        Assert.Contains(result.Errors, e => e.Type == "SampleTracking.SampleShipment" && e.Path.StartsWith("/Samples/0"));
    }

    [Fact]
    public void AcceptsUnspecifiedDateTimeAndNullableFieldsWithoutInventingRequiredProperties()
    {
        var result = catalog.ParseMessage("""{"ShipmentId":1,"Sent":"2026-10-31T12:00:00","Received":null}""");
        var shipment = Assert.IsType<Skyware.Lis.EventsModel.SampleTracking.SampleShipment>(result);
        Assert.Equal(DateTimeKind.Unspecified, shipment.Sent.Kind);
        Assert.Null(shipment.Received);
    }

    [Fact]
    public void ToolResponseSerializesWithoutClrReflectionObjects()
    {
        var result = catalog.ExplainMessage("{\"ShipmentId\":1}");
        var json = JsonSerializer.Serialize(result);
        using var document = JsonDocument.Parse(json);
        Assert.Equal("Matched", document.RootElement.GetProperty("Status").GetString());
        Assert.Equal(1, document.RootElement.GetProperty("Message").GetProperty("ShipmentId").GetInt32());
    }

    [Fact]
    public async Task CatalogSupportsConcurrentReaders()
    {
        var results = await Task.WhenAll(Enumerable.Range(0, 16).Select(_ => Task.Run(() => catalog.ExplainMessage("{\"ShipmentId\":1}"))));
        Assert.All(results, result => Assert.Equal(MessageMatchStatus.Matched, result.Status));
    }

    private static MessageCatalog DiscriminatedCatalog() => new(new()
    {
        DiscriminatorPropertyName = "$type",
        DiscriminatorMappings = new Dictionary<string, string> { ["result"] = "Instruments.Result" }
    });
}
