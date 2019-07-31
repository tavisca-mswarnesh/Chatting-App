using System;
using System.Threading;

namespace ChattingApp
{
    public class ChatApp
    {
        public void Start()
        {
            Thread threadServer = new Thread(() => Listener());
            Thread threadClient = new Thread(() => Client());
            threadServer.Start();
            threadClient.Start();
        }
        public void Listener()
        {
            User user = new User();
            user.IPAddress = "0.0.0.0";
            user.Port = 3000;
            NetworkListener networkListener = new NetworkListener(user);
            Console.WriteLine("Connected:" + networkListener.IsConnected);
            networkListener.StartListening();
            var socket = networkListener.GetSocket();
            Console.WriteLine("Connected:" + networkListener.IsConnected);
            Console.WriteLine("Connected to :" + socket.RemoteEndPoint);
            Console.WriteLine("Press any key to continue");
            Conversation conversation = new Conversation();
            Thread threadReceive = new Thread(() => conversation.Receive(socket));
            Thread threadSend = new Thread(() => conversation.Send(socket));
            threadReceive.Start();
            threadSend.Start();

        }
        public void Client()
        {
            User user = new User();
            string IPAddress = Console.ReadLine();
            if (!string.IsNullOrEmpty(IPAddress))
            {
                user.IPAddress = IPAddress;
                user.Port = 1234;
                try
                {
                    NetworkClient networkClient = new NetworkClient(user);
                    var socket = networkClient.Connect();
                    Console.WriteLine("Connected to :" + socket.RemoteEndPoint);
                    Conversation conversation = new Conversation();
                    Thread threadReceive = new Thread(() => conversation.Receive(socket));
                    Thread threadSend = new Thread(() => conversation.Send(socket));
                    threadReceive.Start();
                    threadSend.Start();
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
