using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace simpleTCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            String message = "Hello It's me";
            int port = 5000;
            String ipAddress = "10.21.247.34";


            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(ipAddress, port);


            NetworkStream netStream = tcpClient.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            netStream.Write(data, 0, data.Length);
        }
    }
}
