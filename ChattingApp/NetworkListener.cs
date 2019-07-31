using System;
using System.Net;
using System.Net.Sockets;

namespace ChattingApp
{
    public class NetworkListener
    {
        private IPAddress _ipAddr;
        private IPEndPoint _localEndPoint;
        private Socket _socket;
        private Socket _clientSocket;
        private Conversation _conversation;
        public bool IsConnected = false;
        public NetworkListener(User user)
        {
            _ipAddr = IPAddress.Parse(user.IPAddress);
            _localEndPoint = new IPEndPoint(_ipAddr, user.Port);
            _socket = new Socket(_ipAddr.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
            _conversation = new Conversation();
        }
        public void StartListening()
        {
            try
            {
                _socket.Bind(_localEndPoint);
                _socket.Listen(10);
                Console.WriteLine("Waiting connection ... ");
                _clientSocket = _socket.Accept();
                IsConnected = true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }
        public Socket GetSocket()
        {
            return _clientSocket;
        }
    }
}
