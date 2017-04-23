using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerStarter : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        // Load the game scene on the server
        if (SystemInfo.graphicsDeviceID == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
