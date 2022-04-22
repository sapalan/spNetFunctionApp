using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;

namespace spNetFunctionApp
{
    public class KafkaTrigger1
    {
        // KafkaTrigger sample 
        // Consume the message from "topic" on the LocalBroker.
        // Add `BrokerList` and `KafkaPassword` to the local.settings.json
        // For EventHubs
        // "BrokerList": "{EVENT_HUBS_NAMESPACE}.servicebus.windows.net:9093"
        // "KafkaPassword":"{EVENT_HUBS_CONNECTION_STRING}
        [FunctionName("KafkaTrigger1_Default_CGroup")]
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
                log.LogInformation($"C# Function 2 Kafka trigger function processed Message Start: {eventData.Value} Partition: {eventData.Partition} Offset {eventData.Offset}");
                log.LogInformation($"C# Kafka trigger function processed a message: {eventData.Value}");
                var vWaitingTimeInMilliSecond  =   (System.Environment.GetEnvironmentVariable("ThreadSleepTimeInMilliSeconds") == null || System.Environment.GetEnvironmentVariable("ThreadSleepTimeInMilliSeconds") =="")?3000:int.Parse(System.Environment.GetEnvironmentVariable("ThreadSleepTimeInMilliSeconds"));
                System.Threading.Thread.Sleep(vWaitingTimeInMilliSecond);
                log.LogInformation($"C# Function 2 Kafka trigger function processed Message End: {eventData.Value} Partition: {eventData.Partition} Offset {eventData.Offset}");
            }
        }
    }
}
