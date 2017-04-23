using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaneManager : MonoBehaviour {

    public GameObject[] pins;
    private int caughtPins;
    private bool hasGutterB;
    private bool allPins;

    public Text scoreText;

	// Use this for initialization
	void Start () {
        caughtPins = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If there are 10 caught pins or not
        allPins = (caughtPins >= 10);

        // Update score on screen above lane
        changeDisplayText();
        // Set gutterball to false just in case a ball got destroyed while in the lane
        hasGutterB = false;
    }
    
    public void ResetPins()
    {
        // Go through each pin and reset its position
        for (int i = 0; i < pins.Length; ++i)
        {
            pins[i].GetComponent<StartPosition>().resetPosition();
        }
    }

    public void addPin()
    {
        // A pin was caught in the back of the lane
        ++caughtPins;
    }

    public void removePin()
    {
        // A pin was removed from the back of the lane
        --caughtPins;
    }

    public void hasGutterBall(bool has)
    {
        // A ball has entered the gutter
        hasGutterB = has;
    }

    private void changeDisplayText()
    {
        // Update screen above lane
        scoreText.text = "Pins: " + caughtPins;

        if (hasGutterB && !allPins)
        {
            scoreText.text += "\n\n\n\n\nGutter Ball!";
        }
        if(allPins)
        {
            scoreText.text += "\n\n\n\n\nWinner!!!";
        }
    }

    public bool hasAllPinsIn()
    {
        return allPins;
    }
}
