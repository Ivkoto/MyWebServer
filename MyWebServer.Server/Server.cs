using System;
using System.Net;

namespace MyWebServer.Server
{
    public class Server
    {
        private readonly IPAddress ipAddress;
        private readonly int port;

        public Server(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress); 
            this.port = port;
        }
    }
}
