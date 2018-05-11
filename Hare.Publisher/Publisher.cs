using System;
using RabbitMQ.Client;
using System.Text;
using Hare.Shared;
using Hare.Shared.Queue;


namespace Hare.Publisher
{
    class Publisher
    {
        private Connection Connection { get; set; }

        static void Main(string[] args)
        {
            ConnectionInformation connectionInformation = new ConnectionInformation();
            Publisher publisher = new Publisher();
            publisher.Connection = new Connection(connectionInformation);
            publisher.Publish();
            Console.ReadLine();
        }

        /// <summary>
        /// Publishes a queue.
        /// </summary>
        private void Publish()
        {
            try
            {
                using (var connection = Connection.GetConnection()) 
                using(var channel = connection.CreateModel())
                {
                    string message = GetUserInput();

                    PublisherQue publisher = new PublisherQue(channel, String.Empty, message);
                    publisher.PublishMessage();

                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem publishing the message to the queue. {0}", exception.Message);
            }

        }

        /// <summary>
        /// Gets user input.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private string GetUserInput()
        {
            Console.WriteLine("Please enter your name: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Outputs message to the user interface.
        /// </summary>
        /// <param name="consoleMessage"></param>
        private void OutputMessage(string consoleMessage)
        {
            Console.WriteLine();
        }
    }
}


