using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    public Slider musicSlider;
    public Slider sfxSlider;

    // Use this for initialization
    void Start () {
        // Set the positions of the sliders to what was previously set
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0F);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1.0F);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateMusicVolume(float newVolume)
    {
        // Set the new stored music volume to what the slider was moved to
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
    }

    public void UpdateSFXVolume(float newVolume)
    {
        // Set the new stored sfx volume to what the slider was moved to
        PlayerPrefs.SetFloat("SFXVolume", newVolume);
    }
}
