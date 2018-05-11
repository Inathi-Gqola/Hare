using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Hare.Shared
{
    public interface IConnectionFactory
    {
        IConnection GetConnection();
    }
}
