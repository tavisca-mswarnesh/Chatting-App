using System;
using System.Net.Sockets;
using System.Text;

namespace ChattingApp
{
    public class Conversation
    {
        public void Receive(Socket socket)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                int bytesReceived = socket.Receive(bytes);
                string message = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
                Console.WriteLine(">" + message);
            }
        }
        public void Send(Socket socket)
        {
            while (true)
            {
                string message = Console.ReadLine();
                byte[] msg = Encoding.ASCII.GetBytes(message);
                int bytesSent = socket.Send(msg);
            }
        }
    }
}
