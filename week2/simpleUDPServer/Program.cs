using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace simpleUDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
             UdpClient udpClient = new UdpClient(5000);
             Console.WriteLine("Server started...");

             for(;;)
             {
                 IPEndPoint endPoint=new IPEndPoint(IPAddress.Any,0);
                 Byte[] recvBytes=udpClient.Receive(ref endPoint);

                 string recvMessage = Encoding.ASCII.GetString(recvBytes);

                 Console.WriteLine(recvMessage);
             }
        }
    }
}
