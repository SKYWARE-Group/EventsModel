# LIS iLab Events Data Model

LIS iLab allows you event-driven integrations, workers, etc. Currently, LIS iLab uses [ActiveMQ Artemis](https://activemq.apache.org/components/artemis/) as a message broker. The messages are JSON serialized objecst which representing different events. Current project is the data model used by different modules of LIS iLab. Note that every massage type inherits `BaseMessage` (abstract class), which has property `DeafultAddress` . This is the address (in term of ActiveMQ borker) where you can expect such an object.

## Usage 

`
Install-Package Skyware.Lis.EventsModel
`
