using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        // Show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void BackToMainMenu()
    {
        // Load main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
