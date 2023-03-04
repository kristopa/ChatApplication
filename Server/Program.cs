using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static TcpListener? _listener;
        static void Main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            _listener.Start();

            var client = _listener.AcceptTcpClient();
            Console.WriteLine("Client has connected!");
        }
    }
}
