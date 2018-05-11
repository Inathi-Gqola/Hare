using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Hare.Shared;
using Hare.Shared.Queue;

namespace Hare.Consumer
{
    class Consumer
    {
        private Connection Connection { get; set; }

        static void Main(string[] args)
        {
            ConnectionInformation connectionInformation = new ConnectionInformation();
            Consumer consumer = new Consumer();
            consumer.Connection = new Connection(connectionInformation);
            consumer.Consume();
        }

        private void Consume()
        {
            using (var connection = Connection.GetConnection())
            using (var channel = connection.CreateModel())
            {
                string key = Shared.Constants.Constant.QueueKey;

                ConsumerQueue consumerQueue = new ConsumerQueue(channel, String.Empty, key);
                consumerQueue.ConsumeMessage();
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}

