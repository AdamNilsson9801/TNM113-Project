using UnityEngine;
using System.IO;

public class OSC : MonoBehaviour
{
    public string serverAddress = "localhost";
    public int serverPort = 57120;
    private OSC _osc;

    void Start()
    {
        _osc = new OSC(serverAddress, serverPort);
        _osc.Start();
    }

    void Update()
    {
        // Send OSC messages to the SuperCollider server
        // For example, you can send a message to set the pitch of a sound
        OscMessage oscMessage = new OscMessage("/pitch", 0.5f);
        _osc.Send(oscMessage);
    }
}