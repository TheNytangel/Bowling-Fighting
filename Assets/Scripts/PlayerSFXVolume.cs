using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXVolume : MonoBehaviour {
    
    private AudioSource playerAudioSource;

    // Use this for initialization
    void Start () {
        // Set the footstep sound effects of the player to what they set in the menu
        playerAudioSource = GetComponent<AudioSource>();
        playerAudioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1.0F);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
