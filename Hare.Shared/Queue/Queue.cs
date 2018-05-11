using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;


namespace Hare.Shared.Queue
{
    /// <summary>
    /// 
    /// </summary>
    public class Queue
    {
        private static IModel channel;
        private static string queueName;
     

        public Queue(IModel _channel, string _queueName)
        {
            channel = _channel;
            queueName = _queueName;
        }

        /// <summary>
        /// Declares a queue.
        /// </summary>
        private void DeclareQueue()
        {
            channel.QueueDeclare(queue: Constants.Constant.QueueKey,
                           durable: false,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);
        }

    }
}
