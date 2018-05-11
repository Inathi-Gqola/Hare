using System;
using System.Collections.Generic;
using System.Text;

namespace Hare.Shared
{
    //todo:: get these from the config file.
    public class ConnectionInformation:IConnectionInformation
    {
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string HostName { get; set; } = "localhost";
    }
}
