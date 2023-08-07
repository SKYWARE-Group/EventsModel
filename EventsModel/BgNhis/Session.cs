// Ignore Spelling: bg uin

namespace Skyware.Lis.EventsModel.BgNhis;


/// <summary>
/// Event. Represent attempt for creation of session in NHIS
/// Default address: topic://bg-nhis/sessions
/// </summary>
public class Session : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://bg-nhis/sessions";

    /// <summary>
    /// If session is made from Arda library (false means Rila server)
    /// </summary>
    public bool IsArda { get; set; } = true;

    /// <summary>
    /// If session was successfully created
    /// </summary>
    public bool IsSucceeded { get; set; }

    /// <summary>
    /// Certificate with which the session was established
    /// </summary>
    public Certificate Certificate { get; set; }

    /// <summary>
    /// Doctor's UIN (according to Bulgarian BMA)
    /// </summary>
    public string Uin { get; set; }

    /// <summary>
    /// Practice number associated with this record
    /// </summary>
    public string PracticeNumber { get; set; }

    /// <summary>
    /// Description of the error, in case of creation failure
    /// </summary>
    public string FailureReason { get; set; }

}
