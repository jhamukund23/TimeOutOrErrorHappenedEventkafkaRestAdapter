using Kafka.Constants;
using Kafka.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace TimeOutOrErrorkafkaRestAdapter
{
    public class MessageConsumer : BackgroundService
    {
        private readonly IKafkaConsumer<string, AddDocument> _consumer;
        public MessageConsumer(IKafkaConsumer<string, AddDocument> kafkaConsumer)
        {
            _consumer = kafkaConsumer;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _consumer.Consume(KafkaTopics.AddDocumentRequest, stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{(int)HttpStatusCode.InternalServerError} ConsumeFailedOnTopic - {KafkaTopics.AddDocumentRequest}, {ex}");
            }
        }

        public override void Dispose()
        {
            _consumer.Close();
            _consumer.Dispose();

            base.Dispose();
        }
    }
}
