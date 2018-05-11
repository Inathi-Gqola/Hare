using RabbitMQ;
using RabbitMQ.Client;

namespace Hare.Shared
{
    public class Connection:IConnectionFactory
    {
        private readonly ConnectionInformation connectionInformation;

        public Connection(ConnectionInformation connectionInformation)
        {
            this.connectionInformation = connectionInformation;
        }

        public IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                UserName = connectionInformation.UserName,
                Password = connectionInformation.Password,
                HostName = connectionInformation.HostName
            };

            var connection = connectionFactory.CreateConnection();

            return connection;
        }
    }
}
