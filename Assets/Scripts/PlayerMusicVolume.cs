using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusicVolume : MonoBehaviour {

    // BACKGROUND MUSIC FROM:
    // https://www.youtube.com/watch?v=Qp5QRn1LVw0
    // User: AdventuresinHD (https://www.youtube.com/channel/UCX-cRQF8rUrbNS9jJFfwSDQ)

    private AudioSource playerAudioSource;

	// Use this for initialization
	void Start () {
        // Set the background music of the player to what they set in the menu
        playerAudioSource = GetComponent<AudioSource>();
        playerAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0F);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
