using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Pause : MonoBehaviour {

    public GameObject pauseMenu;
    public bool isPause;

	// Use this for initialization
	void Start () {

        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerInputManager.Pause())
        {

            PauseCheck();            
        }
	}

    public void EnablePauseMenu()
    {
        isPause = true;
        pauseMenu.SetActive(true);
        pauseMenu.transform.GetChild(1).gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisablePauseMenu()
    {
        isPause = false;
        pauseMenu.transform.GetChild(0).gameObject.SetActive(true);
        pauseMenu.transform.GetChild(2).gameObject.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseCheck()
    {
        if (isPause == false)
        {
            EnablePauseMenu();
        }
        else
        {
            DisablePauseMenu();
        }
    }
}
