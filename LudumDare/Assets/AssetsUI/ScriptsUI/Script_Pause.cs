using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Pause : MonoBehaviour {

    public GameObject pauseMenu;
    public bool isPause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            PauseCheck();            
        }
	}

    public void EnablePauseMenu()
    {
        Time.timeScale = 0;
        isPause = true;
        Debug.Log(Time.timeScale);
        pauseMenu.SetActive(true);
    }

    public void DisablePauseMenu()
    {
        Time.timeScale = 1;
        isPause = false;
        Debug.Log(Time.timeScale);
        pauseMenu.SetActive(false);
    }

    public void PauseCheck()
    {
        if (isPause == false)
        {
            EnablePauseMenu();
        }

        else
            DisablePauseMenu();
    }
}
