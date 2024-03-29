﻿using System.Collections.Generic;

namespace Skyware.Lis.EventsModel.Instruments;

/// <summary>
/// Occurs when LIS sends a sample order to an <see cref="Instrument"/>
/// </summary>
public class Order : BaseMessage
{

    /// <inheritdoc/>
    public override string DefaultAddress => "topic://instruments/orders";

    /// <summary>
    /// <see cref="Instrument"/> to which the order is sent
    /// </summary>
    public Instrument Instrument { get; set; }

    /// <summary>
    /// Ordered <see cref="Sample"/>
    /// </summary>
    public Sample Sample { get; set; }


    /// <summary>
    /// Ordered items (Array of <see cref="Test"/>)
    /// </summary>
    public IEnumerable<Test> Tests { get; set; }

}
