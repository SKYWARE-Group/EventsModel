namespace Skyware.Lis.EventsModel.Instruments;

/// <summary>
/// Occurs when  <see cref="Instruments.Instrument"/> queries test selection by Sample Id (barcode).
/// </summary>
public class Query : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://instruments/queries";

    /// <summary>
    /// <see cref="Instruments.Instrument"/> which made the query.
    /// </summary>
    public Instrument Instrument { get; set; }

    /// <summary>
    /// <see cref="Instruments.Sample"/>, subject of the query.
    /// </summary>
    public Sample Sample { get; set; }


}
