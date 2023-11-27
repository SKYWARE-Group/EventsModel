# <img src="EventsModel/Assets/event-sys-icon.png" height="26"> LIS iLab Events Data Model

[LIS iLab](https://ilab.skyware-group.com/) allows you event-driven integrations, workers, etc. Currently, LIS iLab uses [ActiveMQ Artemis](https://activemq.apache.org/components/artemis/) as a message broker. The messages are JSON serialized objecst which representing different events. Current project is the data model used by different modules of LIS iLab. 

## Usage 

![Nuget](https://img.shields.io/nuget/v/Skyware.Lis.EventsModel?logo=nuget&label=Skyware.Lis.EventsModel&color=rgb(0%2C%20204%2C%200))

The easiest way is to get and use the library in your project is with [NuGet package](https://www.nuget.org/packages/Skyware.Lis.EventsModel) like tnat:

```
Install-Package Skyware.Lis.EventsModel
```

## Documentation

Read the documentaion and see the object model on [this site](https://skyware-group.github.io/EventsModel/articles/getting-started.html).

## End to end example

You could use example code in [TestApp](TestApp/Program.cs) for fast project bootstrap. This application uses [Apache.NMS](https://activemq.apache.org/components/nms/) client library
(AMQP 1.0 protocol) which you could include in your project with [NuGet package](https://www.nuget.org/packages/Apache.NMS.ActiveMQ).

```
Install-Package Apache.NMS.ActiveMQ
```
## Other use cases

Usually you will be able to use other protocols, such as MQTT (see [client](https://github.com/dotnet/MQTTnet)). If you nedd web browser aproach,
then we recomment [STOMP over SockJS](https://stomp-js.github.io/guide/stompjs/rx-stomp/using-stomp-with-sockjs.html).

## Feedback

Please, use issues in this repo as a first step for getting support from us

----
&copy; 2022-2023, SKYWARE Group
