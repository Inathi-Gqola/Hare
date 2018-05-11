using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Hare.Shared.Queue
{
    /// <summary>
    /// Creates a queue for publishing messages.
    /// </summary>
    public class PublisherQue:Queue
    {
        string message;
        private static IModel channel;
        private static string queueName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_channel"></param>
        /// <param name="_exchange"></param>
        /// <param name="_message"></param>
        public PublisherQue(IModel _channel, string _exchangeName, string _message)
          : base(_channel, _exchangeName)
        {
            channel = _channel;
            queueName = _exchangeName;
            message = _message;
        }

        /// <summary>
        /// Encodes a given string and returns a byte array.
        /// </summary>
        /// <returns></returns>
        private byte[] GetEncodedMessage()
        {
            return Encoding.UTF8.GetBytes(this.message);
        }

        /// <summary>
        /// Publishes a message to the queue.
        /// </summary>
        public void PublishMessage()
        {
            byte[] body = GetEncodedMessage();

            channel.BasicPublish(exchange: "",
                                routingKey: Constants.Constant.QueueKey,
                                basicProperties: null,
                                body: body);
        }

    }
}
