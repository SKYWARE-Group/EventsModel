namespace Skyware.Lis.EventsModel.Instruments;


/// <summary>
/// Occurs when results is received from an <see cref="Instrument"/> 
/// </summary>
public class Result : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://instruments/results";

    /// <summary>
    /// <see cref="Instrument"/> from which the result is received
    /// </summary>
    public Instrument Instrument { get; set; }

    /// <summary>
    /// <see cref="Sample"/> being tested
    /// </summary>
    public Sample Sample { get; set; }

    /// <summary>
    /// Examination results (<see cref="ResultData"/>)
    /// </summary>
    public ResultData Data { get; set; }

}
