using System.Net;
using System.Net.Sockets;

namespace ChattingApp
{
    public class NetworkClient
    {
        private IPAddress _ipAddr;
        private IPEndPoint _localEndPoint;
        private Socket _socket;
        public NetworkClient(User user)
        {
            _ipAddr = IPAddress.Parse(user.IPAddress);
            _localEndPoint = new IPEndPoint(_ipAddr, user.Port);
            _socket = new Socket(_ipAddr.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
        }
        public Socket Connect()
        {
            _socket.Connect(_localEndPoint);

            return _socket;
        }
    }
}
