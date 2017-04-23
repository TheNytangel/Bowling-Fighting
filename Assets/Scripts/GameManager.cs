using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public NetworkManager networkManager;
    public LaneManager[] lanes;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Reset pins every minute and a half
        InvokeRepeating("ResetLanes", 90.0F, 90.0F);
    }

    // Update is called once per frame
    void Update () {
        // On escape, stop the client and load the main menu
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            networkManager.StopClient();
            SceneManager.LoadScene("MainMenu");
        }

        // If won, stop the client and load win scene
        if(CheckIfWon())
        {
            networkManager.StopClient();
            SceneManager.LoadScene("Win");
        }
    }

    void ResetLanes()
    {
        // Go through every lane in the array and reset its pins
        for(int i = 0; i < lanes.Length; ++i)
        {
            lanes[i].ResetPins();
        }
    }

    bool CheckIfWon()
    {
        // Go through every lane in the array and check if it has all of its pins in the hole
        for (int i = 0; i < lanes.Length; ++i)
        {
            if (!lanes[i].hasAllPinsIn())
                return false;
        }

        return true;
    }
}
