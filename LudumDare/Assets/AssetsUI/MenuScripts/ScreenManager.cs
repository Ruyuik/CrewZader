using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour {

    public AudioMixer audioMixer;

    public Slider volumeSlider;


    // Use this for initialization
    void Start () {
        AudioListener audioListener = FindObjectOfType<AudioListener>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewRun()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FullscreenToggle()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volumeSlider.value;
    }
}