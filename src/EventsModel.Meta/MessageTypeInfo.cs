namespace Skyware.Lis.EventsModel.Meta;

/// <summary>
/// Discoverable message type, its XML documentation and default broker address.
/// </summary>
public sealed record MessageTypeInfo(string Type, string ClrType, string Description, string DefaultAddress);
