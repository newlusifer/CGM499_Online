using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class privateChat : MonoBehaviour
{ static SocketIOComponent socket;

    public string inputText = "Hello World";
    public string displayText = "";


    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);        

        socket.On("message.send",OnListenerMessage);

    }

    private void OnListenerMessage(SocketIOEvent obj)
    {
        string msg=obj.data["message"].str;

        displayText += msg+System.Environment.NewLine;
    }


    private void OnConnected(SocketIOEvent obj)
    {
        Debug. Log("conected");
    }



    void OnGUI()
    {
        displayText = GUI. TextArea(new Rect(10, 10, 500, 100), displayText, 25);


        inputText = GUI. TextField(new Rect(10, 120, 500, 20), inputText, 25);



        if (GUI. Button(new Rect(10, 160, 50, 30), "Send"))
        {
            JSONObject jSONObject=new JSONObject(JSONObject.Type.OBJECT);
            jSONObject.AddField("message",inputText);
            socket.Emit("message.send",jSONObject);

            
        }



    }


}
