using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Program
    {
        public static async Task Main()
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var port = 8080;

            var serverListener = new TcpListener(ipAddress, port);

            serverListener.Start();

            var connection = await serverListener.AcceptSocketAsync();
        }
    }
}
