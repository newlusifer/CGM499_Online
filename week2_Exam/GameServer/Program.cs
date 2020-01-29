using System;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

using System.Collections.Generic; 

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
             //int actualNumber = 70;
            
            Random random = new Random();
            int actualNumber = random.Next(0,100);

            UdpClient client = null;

            int servPort = 5000;    

            int guessNumber=0;        
            string playerName="";

            int StatusRandom=0;

            try
            {
                // Create an instance of UdpClient on the port to listen on
                client = new UdpClient(servPort);
                Console.WriteLine("Server Started...");

            }
            catch (SocketException se)
            {
                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                Environment.Exit(se.ErrorCode);
            }


            // Create an IPEndPoint instance that will be passed as a reference
            // to the Receive() call and be populated with the remote client info
            IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);



            for (; ; )
            {  // Run forever, receiving and echoing datagrams
                try
                {
                    // Receive a byte array with echo datagram packet contents
                    byte[] byteBuffer = client.Receive(ref remoteIPEndPoint);
                   // Console.Write("Handling client at " + remoteIPEndPoint + " - ");                   

                    try
                    {
                        String recvText = Encoding.ASCII.GetString(byteBuffer, 0, byteBuffer.Length);
                   // Console.WriteLine(recvText);
                     guessNumber = Convert.ToInt16(recvText);                    

                    String responseMessage = "";
                    if (guessNumber == actualNumber)
                    {
                        responseMessage = playerName+" You Are Winner";                       
                        StatusRandom=1;
                    }
                    if (guessNumber > actualNumber)
                    {
                        responseMessage = guessNumber+" is too high";

                        //Console.WriteLine("too high");
                    }

                    if (guessNumber < actualNumber)
                    {
                        responseMessage = guessNumber+" is too low";

                        //Console.WriteLine("too low");
                    }

                    if(StatusRandom==1)
                    {
                         actualNumber = random.Next(0,100);
                         Console.WriteLine("RanDom!!!");
                         StatusRandom=0;
                    }



                    Byte[] responseBytes = Encoding.ASCII.GetBytes(responseMessage);
                    client.Send(responseBytes, responseBytes.Length, remoteIPEndPoint);



                    }

                    catch
                    {
                         String recvTextName = Encoding.ASCII.GetString(byteBuffer, 0, byteBuffer.Length);                                        
                         playerName=recvTextName;
                         Console.WriteLine(playerName + " : "+guessNumber);  //displayText
                    }

                    
                    
                    // Send an echo packet back to the client
                    //client.Send(byteBuffer, byteBuffer.Length, remoteIPEndPoint);
                    //Console.WriteLine("echoed {0} bytes.", byteBuffer.Length);
                }
                catch (SocketException se)
                {
                    Console.WriteLine(se.ErrorCode + ": " + se.Message);
                }
            }
            

        }//end main   
    }
}
