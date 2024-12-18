﻿using Apache.NMS;
using Apache.NMS.Util;
using Microsoft.Extensions.Configuration;
using Skyware.Lis.EventsModel.SampleTracking;
using Skyware.Lis.EventsModel.Common;
using Spectre.Console;
using Spectre.Console.Json;
using System;
using System.Text.Json;
using System.IO;
using Skyware.Lis.EventsModel;

namespace BrokerClient48
{
    internal class Program
    {

        public const string SETTINGS_FILE = "appsettings.json";
        public const string KEY_URI = "ActiveMq:Uri";
        public const string KEY_USER = "ActiveMq:User";
        public const string KEY_PASSWORD = "ActiveMq:Password";

        static void Main(string[] args)
        {
            DoPubSub();
        }

        private static void DoPubSub()
        {

            // Configuration
            IConfigurationRoot conf = BuildConfig();
            AnsiConsole.MarkupLine("[gray]Configuration file is read.[/]");

            // Connection factory
            IConnectionFactory factory = new NMSConnectionFactory(new Uri(conf[KEY_URI] ?? throw new ApplicationException($"Missing key {KEY_URI} in {SETTINGS_FILE}.")));
            AnsiConsole.MarkupLine("[gray]Connection factory is built.[/]");

            // Connection
            using (IConnection connection = factory.CreateConnection(
                conf[KEY_USER] ?? throw new ApplicationException($"Missing key {KEY_USER} in {SETTINGS_FILE}."),
                conf[KEY_PASSWORD] ?? throw new ApplicationException($"Missing key {KEY_PASSWORD} in {SETTINGS_FILE}.")))
            {


                AnsiConsole.MarkupLine("[gray]Connection is created.[/]");

                connection.ConnectionInterruptedListener += () => AnsiConsole.MarkupLine($"[red1]Connection is interrupted.[/]");
                connection.ConnectionResumedListener += () => AnsiConsole.MarkupLine($"[green3]Connection is resumed.[/]");
                connection.ExceptionListener += (Exception exception) => AnsiConsole.MarkupLine($"[red1]Exception: {exception.Message}.[/]");

                // Session
                using (ISession session = connection.CreateSession(AcknowledgementMode.ClientAcknowledge))
                {
                    AnsiConsole.MarkupLine("[gray]Session is created.[/]");

                    // Destination
                    using (IDestination destination = SessionUtil.GetDestination(session, new CheckIn().DefaultAddress))  // Samples check in and out address
                    {
                        AnsiConsole.MarkupLine($"[gray]Destination for {nameof(CheckIn)} is created.[/]");

                        // Producer
                        using (IMessageProducer producer = session.CreateProducer(destination))
                        {
                            producer.DeliveryMode = MsgDeliveryMode.Persistent;
                            producer.RequestTimeout = TimeSpan.FromSeconds(10);
                            AnsiConsole.MarkupLine("[gray]Producer is created.[/]");

                            // Consumer
                            using (IMessageConsumer consumer = session.CreateConsumer(destination))
                            {
                                consumer.Listener += new MessageListener((IMessage message) =>
                                {
                                    AnsiConsole.MarkupLine($"[green3]Message is received:{Environment.NewLine}[/]");
                                    AnsiConsole.Write(
                                    new Panel(new JsonText(((ITextMessage)message).Text))
                                        .Header("Payload:")
                                        .Collapse()
                                        .RoundedBorder()
                                        .BorderColor(Color.Yellow));
                                });
                                AnsiConsole.MarkupLine("[gray]Consumer is created.[/]");

                                // Start connection
                                connection.Start();

                                // Base message (serialization test)
                                BaseMessage baseMessage;

                                // Send a message
                                CheckIn checkIn = new CheckIn()
                                {
                                    OriginApp = "Demo",
                                    IsCheckIn = true,
                                    Sample = new Sample() { Barcode = "AX34RG6", LaboratoryCode = "SERUM" },
                                    OriginHost = Environment.MachineName,
                                    OriginLocation = new Location() { Id = 5, Name = "Central lab", Code = "CNTR" },
                                    OriginUserId = Environment.UserName,
                                };

                                baseMessage = checkIn;

                                ITextMessage msg = session.CreateTextMessage(JsonSerializer.Serialize(
                                    baseMessage,
                                    baseMessage.GetType(),
                                    new JsonSerializerOptions() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }));
                                msg.NMSCorrelationID = Guid.NewGuid().ToString();
                                msg.Properties["NMSXGroupID"] = "System";
                                msg.Properties["myHeader"] = "iLab";
                                producer.Send(msg);
                                AnsiConsole.MarkupLine($"[green3]Message is sent.[/]");

                                AnsiConsole.MarkupLine("Listening for messages, press any key to exit...");
                                Console.ReadKey();
                                connection.Stop();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Configure the application (appsettings.json) and injects user secrets.
        /// </summary>
        private static IConfigurationRoot BuildConfig()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(SETTINGS_FILE, optional: false, reloadOnChange: false);
            return builder.Build();
        }
    }
}
