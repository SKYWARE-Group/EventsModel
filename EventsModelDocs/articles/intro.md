## Basics

In the Software Architecture Patterns (Mark Richards):
> The event-driven architecture pattern is a popular distributed asynchronous architecture pattern used 
to produce highly scalable applications. The event-driven architecture is made up of highly decoupled, 
single-purpose event processing components that asynchronously receive and process events.

iLab Events System is intended to deliver real-time messages between different modules, applications and systems, 
thus making event driven architecture possible. It is implemented with 
[Apache ActiveMQ Artemis](https://activemq.apache.org/components/artemis/){:target="_blank"}. 
The main approach is 
[Publish-Subscribe pattern](https://en.wikipedia.org/wiki/Publish%E2%80%93subscribe_pattern){:target="_blank"}. 
The idea is to generate a message on every event in the system (e.g. patient is 
registered, result is entered, etc.) and to notify anyone who is interested in this particular event.

## Example usage

Let say you want to integrate [CRM system](https://en.wikipedia.org/wiki/Customer_relationship_management) 
with LIS iLab. In this case, doctors would be a subject of synchronization between systems as they would be 
contacts in the CRM. You could develop an application to do that on a schedule, but that means you will 
have "blind periods" in which the records in one of the systems will be incorrect. To avoid that, you need 
to know when a given record has been added, modified or deleted. And the Events System gives you what you 
need - real time messaging, that will inform you for such events. 
So, you could subscribe your system to listen for messages in a given topic (doctors in the given example). 
Once you have a message, for example after adding a new doctor in LIS iLab, you will immediately synchronize 
the new record with your CRM. The end user will see the new records in your CRM immediately after they are 
entered in LIS iLab. That's it! 

## Object model

The messages are just serialized JSON objects. The reference object model is maintained as an open source 
project in this repository. If you using .NET you can use it directly as a NuGet package. In this documentation you will find addresses and expected objects as well as short descriptions for every event is produced.



