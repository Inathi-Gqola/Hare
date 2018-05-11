using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Hare.Shared.Queue
{
    public class ConsumerQueue:Queue
    {
        private static IModel channel;
        private static string queueName;
        private static string exchangeName;

        public ConsumerQueue(IModel _channel, string _exchangeName, string _queueName) 
            : base(_channel, _exchangeName)
        {
            channel = _channel;
            exchangeName = _exchangeName;
            queueName = _queueName;
        }

        /// <summary>
        /// Consumes a message from the queue.
        /// </summary>
        public void ConsumeMessage()
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };
            channel.BasicConsume(queue: Constants.Constant.QueueKey,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
