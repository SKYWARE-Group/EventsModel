# <img src="EventsModel/Assets/EventSysIcon.png" height="26"> LIS iLab Events Data Model

[LIS iLab](https://ilab.skyware-group.com/) allows you event-driven integrations, workers, etc. Currently, LIS iLab uses [ActiveMQ Artemis](https://activemq.apache.org/components/artemis/) as a message broker. The messages are JSON serialized objecst which representing different events. Current project is the data model used by different modules of LIS iLab. Note that every massage type inherits `BaseMessage` (abstract class), which has property `DeafultAddress` . This is the address (in term of ActiveMQ borker) where you can expect such an object.

## Usage 

The easiest way is to get the library trough [NuGet package](https://www.nuget.org/packages/Skyware.Lis.EventsModel) like tnat:

`
Install-Package Skyware.Lis.EventsModel
`

## Notes

Typical connection URL is like `activemq:failover:ssl://some-host.com:61616?transport.acceptInvalidBrokerCert=true`. Also you will need username and password to acces the ActiveMQ server. 
