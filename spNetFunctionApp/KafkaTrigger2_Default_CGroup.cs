using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;

namespace spNetFunctionApp
{
    public class KafkaTrigger2_Default_CGroup
    {
        // KafkaTrigger sample 
        // Consume the message from "topic" on the LocalBroker.
        // Add `BrokerList` and `KafkaPassword` to the local.settings.json
        // For EventHubs
        // "BrokerList": "{EVENT_HUBS_NAMESPACE}.servicebus.windows.net:9093"
        // "KafkaPassword":"{EVENT_HUBS_CONNECTION_STRING}
        [FunctionName("KafkaTrigger2_Default_CGroup")]
        public static void Run(
           [KafkaTrigger("pkc-7prvp.centralindia.azure.confluent.cloud:9092",
                          "Topic1",
                          Username = "Q2L7LHNXQEYMFKRQ",
                          Password = "kYIhvBC2QOUsuCTpl02o/olvjJPI594aIgYQ9GnvybY7fp7yPYIavF6yNc8A9a9W",
                          Protocol = BrokerProtocol.SaslSsl,
                          AuthenticationMode = BrokerAuthenticationMode.Plain,
                          ConsumerGroup = "$Default")] KafkaEventData<string>[] events, ILogger log)
        {
            foreach (KafkaEventData<string> eventData in events)
            {
                log.LogInformation($"C# Kafka trigger function processed a message: {eventData.Value}");
            }
        }
    }
}
