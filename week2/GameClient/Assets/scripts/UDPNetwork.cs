using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDPNetwork : MonoBehaviour
{

    // receiving Thread
    Thread receiveThread;
    public string message = "Hello World";

    // udpclient object
    UdpClient client;

    // public
    // public string IP = "127.0.0.1"; default local


    public int port = 5000;
    public String ipAddress = "127.0.0.1";

    private UdpClient udpClient;


    public String lastRecvMessage;
    public String[] allRecvMessage;

    public void Start()
    {
        udpClient = new UdpClient();
        udpClient.Connect(ipAddress, port);


        init();
    }

    private static void Main()
    {
        UDPNetwork receiveObj = new UDPNetwork();
        receiveObj.init();

    }

    private void init()
    {



        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    void OnGUI()
    {


        message = GUI.TextField(new Rect(10, 10, 200, 20), message, 25);


        if (GUI.Button(new Rect(50, 50, 150, 100), "Send"))
        {


            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            udpClient.Send(sendBytes, sendBytes.Length);


            print("sent!");

        }
    }



    private void ReceiveData()
    {

        //client = new UdpClient();
        while (true)
        {

            try
            {
                // Bytes empfangen.
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = udpClient.Receive(ref anyIP);

                // Bytes mit der UTF8-Kodierung in das Textformat kodieren.
                string text = Encoding.UTF8.GetString(data);

                print(text);

                lastRecvMessage = text;

            }
            catch (Exception err)
            {

            }
        }
    }


    void OnApplicationQuit()
    {
        receiveThread.Abort();

    }


}