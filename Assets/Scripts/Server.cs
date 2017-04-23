using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : NetworkBehaviour {

    NetworkManager nwm;

	// Use this for initialization
	void Start () {
        nwm = GetComponent<NetworkManager>();

        // If the game was specified to run without graphics, it's the server, so start the server
        if(SystemInfo.graphicsDeviceID == 0)
        {
            nwm.StartServer();
        }
        else
        {
            // If this is a development build, connect to the server on localhost. Otherwise, it will try to connect to bowling.chrisp.me
            if(Debug.isDebugBuild)
            {
                nwm.networkAddress = "localhost";
            }

            // Try to connect the client to the server
            nwm.StartClient();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
