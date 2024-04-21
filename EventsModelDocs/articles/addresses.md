## Visits

### Sale
The `Sale` event occurs when Sale is created, modified or deleted.

| Key | Value |
|:--- |:--- |
| Address | `topic://sales` |
| Object | `Skyware.Lis.EventsModel.Visits.Sale` |
| Events | Sale is created, modified or deleted (see `CommonEvents`) |
| Applications | iReg |

### Result
The `ResultsSet` event occurs when one or more results are modified or deleted.

| Key | Value |
|:--- |:--- |
| Address | `"topic://results"` |
| Object | `Skyware.Lis.EventsModel.Results.ResultsSet` |
| Events | One or more Visit's results are changed |
| Applications | iLab |

## Instruments

### Query
The `Query` event occurs when a laboratory instrument scans a barcoded sample and request LIS for test selection.

| Key | Value |
|:--- |:--- |
| Address | `topic://instruments/queries` |
| Object | `Skyware.Lis.EventsModel.Instruments.Query` |
| Events | Test selection inquiry |
| Applications | iLink |

### Order
The `Order` event occurs when iLink makes an order to the instrument.

| Key | Value |
|:--- |:--- |
| Address | `topic://instruments/orders` |
| Object | `Skyware.Lis.EventsModel.Instruments.Order` |
| Events | Test selection is ordered |
| Applications | iLink |

### Result
The `Result` event occurs when a laboratory instrument reports one or more results to iLink.

| Key | Value |
|:--- |:--- |
| Address | `topic://instruments/results` |
| Object | `Skyware.Lis.EventsModel.Instruments.Result` |
| Events | One or more results are sent to iLink |
| Applications | iLink |

### Result Approval
The `ResultApproval` event occurs when previously received result is approved (validated) 
and sent (saved) to the LIS, either automatically or manually.

| Key | Value |
|:--- |:--- |
| Address | `topic://instruments/result-approvals` |
| Object | `Skyware.Lis.EventsModel.Instruments.ResultApproval` |
| Events | Result is approved and sent to LIS |
| Applications | iLink |

This event is known to be handled by the InfinityLink application.

## Payments

### Payment
The `Payment` event occurs when a patient payment is registered or when the operator (receptionist) made refund.

| Key | Value |
|:--- |:--- |
| Address | `topic://payments` |
| Object | `Skyware.Lis.EventsModel.Payments.Payment` |
| Events | Payment or Refund is made |
| Applications | iReg |

## Sample logistics

### Check-in
The `CheckIn` event occurs when a sample is checked in or out of given location.

| Key | Value |
|:--- |:--- |
| Address | `topic://smp-tracking/check-in` |
| Object | `Skyware.Lis.EventsModel.SampleTracking.CheckIn` |
| Events | Sample check-in, Sample check-out |
| Applications | iLab |

### Sample Shipment
The `SampleShipment` event occurs when sample shipment was sent or received.

| Key | Value |
|:--- |:--- |
| Address | `topic://smp-tracking/shipments` |
| Object | `Skyware.Lis.EventsModel.SampleTracking.SampleShipment` |
| Events | Sample Shipment is sent or received |
| Applications | iLab |

## NHIS (НЗИС)

### NHIS Sessions (НЗИС сесии)
The `Session` event occurs when an application make a session with Bulgarian NHIS (НЗИС).

| Key | Value |
|:--- |:--- |
| Address | `topic://bg-nhis/sessions` |
| Object | `Skyware.Lis.EventsModel.BgNhis.Session` |
| Events |TODO |
| Applications |TODO |


### NHIS Referrals (НЗИС направления)

The `ReferralAction` event occurs when an application interacts with Bulgarian NHIS (НЗИС) for a particular referral. 
Actions are defined as constants in `ReferralEvents`.

| Key | Value |
|:--- |:--- |
| Address | `topic://bg-nhis/referrals` |
| Object | `Skyware.Lis.EventsModel.BgNhis.ReferralAction` |
| Events | Imported, Locked, Unlocked, Removed (see `ReferralEvents`) |
| Applications | iReg |

## NRA (НАП)

### Health Insurance Check
The `InsuranceCheck` event occurs when an application make an health insurance check against Bulgarian NRA (НАП).

| Key | Value |
|:--- |:--- |
| Address |`topic://bg-nra/insurance-checks` |
| Object |`Skyware.Lis.EventsModel.BgNra.InsuranceCheck` |
| Events | Health insurance check is performed |
| Applications | iReg |

