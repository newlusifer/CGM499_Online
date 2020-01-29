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

    public string playerName="";

    public string ServerMessage = "";

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
        GUI.TextArea(new Rect(400,50,200,30),"PlayerName : "+playerName,100);

        GUI.TextArea(new Rect(50, 200, 300, 30), "Server : " + ServerMessage, 100);

        playerName = GUI.TextField(new Rect(700, 50, 200, 20), playerName, 25);

        message = GUI.TextField(new Rect(50, 10, 200, 20), message, 25);
        

        if (GUI.Button(new Rect(50, 50, 150, 100), "Send"))
        {


            //Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            int[] test =new int[] { 50, 100 };
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            udpClient.Send(sendBytes, sendBytes.Length);
            Debug.Log(message);

            Byte[] sendName = Encoding.ASCII.GetBytes(playerName);
            udpClient.Send(sendName, sendName.Length);
            Debug.Log(playerName);

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


                ServerMessage = text;

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