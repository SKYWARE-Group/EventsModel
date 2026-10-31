namespace Skyware.Lis.EventsModel.Instruments;

/// <summary>
/// Occurs when results is received from an <see cref="Instruments.Instrument"/>.
/// </summary>
public class Result : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://instruments/results";

    /// <summary>
    /// <see cref="Instruments.Instrument"/> from which the result is received.
    /// </summary>
    public Instrument Instrument { get; set; }

    /// <summary>
    /// <see cref="Instruments.Sample"/> being tested.
    /// </summary>
    public Sample Sample { get; set; }

    /// <summary>
    /// Examination results (<see cref="ResultData"/>).
    /// </summary>
    public ResultData Data { get; set; }

}
