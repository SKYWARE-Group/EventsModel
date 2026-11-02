using Skyware.Lis.EventsModel.Common;

namespace Skyware.Lis.EventsModel.Catalog;

/// <summary>
/// Occurs when reference data (a catalog entry) has been created, changed or deleted.
/// </summary>
/// <remarks>
/// The message says which entry changed, not how: it carries no property values, so it is safe to broadcast and
/// subscribers that cache LIS data read the current state from the database. Delivery is not guaranteed: a message may
/// be lost, repeated or arrive out of order, and changes made outside the emitting application (other LIS applications,
/// SQL scripts) emit nothing, so caches still need an expiry or a periodic refresh. Because a subscriber re-reads the
/// entry, a repeated or late message is harmless. Use <see cref="OperationId"/> to handle the messages of one save
/// together.
/// </remarks>
public class EntryChange : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://catalog/entry";

    /// <summary>
    /// Primary key of the entry in the database, or null when the change concerns many entries of the table at once
    /// (e.g. a cascading or bulk delete or an import), which subscribers treat as "the whole table may have changed".
    /// </summary>
    /// <remarks>
    /// A single key is its invariant text, e.g. "42" or "general.robin-url". A composite key is a JSON array of its
    /// values in the key order of the LIS Model type, e.g. "[12,5]".
    /// </remarks>
    public string EntryId { get; set; }

    /// <summary>
    /// Name of the database table where the entry is stored, without the schema, e.g. "Tests" or "SampleTypes".
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// Fully qualified name of the entry's type in the LIS Model library, e.g. "Skyware.Lis.Model.Test".
    /// </summary>
    public string TypeName { get; set; }

    /// <summary>
    /// What happened to the entry, according to <see cref="CommonEvents"/>: "Created", "Updated" or "Deleted".
    /// </summary>
    /// <remarks>
    /// Without <see cref="EntryId"/> it is "Updated": entries of the table may have been created, changed or deleted.
    /// </remarks>
    public string EventType { get; set; } = CommonEvents.UPDATED;

    /// <summary>
    /// Identifier (GUID) shared by every message of one save, e.g. a record and its child entries saved together.
    /// </summary>
    public string OperationId { get; set; }

}
