using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace simpleTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = null;
            int port = 5000;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            //byte[] rcvBuffer = new byte[BUFSIZE]; // Receive buffer
            int bytesRcvd;

            Console.WriteLine("Server started...");

            for (; ; )
            {
                TcpClient tcpClient = null; 
                NetworkStream netStream = null;

                tcpClient = listener.AcceptTcpClient(); // Get client connection netStream = client.GetStream();
                
                
                netStream = tcpClient.GetStream();
                
                Console.Write("Handling client - ");


                byte[] data = new byte[tcpClient.ReceiveBufferSize];
                int numBytesRead = netStream.Read(data, 0, Convert.ToInt32(tcpClient.ReceiveBufferSize)); 
                Console.WriteLine("Recieve :" + Encoding.ASCII.GetString(data, 0, numBytesRead));
                tcpClient.Close();


                /*
                int totalBytesEchoed = 0;
                while ((bytesRcvd = netStream.Read(rcvBuffer, 0, rcvBuffer.Length)) > 0) {
                        netStream.Write(rcvBuffer, 0, bytesRcvd);
                        totalBytesEchoed += bytesRcvd; 
                }
                */

            }


            Console.WriteLine("Server terminated...");

        }
    }
}
