﻿namespace Skyware.Lis.EventsModel.BgNhis;


/// <summary>
/// Represents e-signature (X509 certificate on chip and supplemental data)
/// </summary>
public class Certificate
{

    /// <summary>
    /// Serial number of the certificate
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// Friendly name of the Rila record or Subject of the certificate
    /// </summary>
    public string FriendlyName { get; set; }

}
