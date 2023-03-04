using Client.Net.IO;
using System;
using System.Net.Sockets;

namespace Client.Net
{
    internal class Server
    {
        TcpClient _client;

        public Server()
        {
            _client = new TcpClient();
        }

        public void ConnectToServer(string username)
        {
            if(!_client.Connected)
            {
                _client.Connect("127.0.0.1", 8080);
                var connectPacket = new PacketBuilder();
                connectPacket.WriteOpCode(0);
                connectPacket.WriteString(username);
                _client.Client.Send(connectPacket.GetPacketBytes());
            }
        }
    }
}
