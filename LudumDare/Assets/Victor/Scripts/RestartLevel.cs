using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;


public class RestartLevel : MonoBehaviour {


    public void Restart()
    {
        Time.timeScale = 1;
        int currentLevel = Application.loadedLevel;
        Application.LoadLevel(currentLevel);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }
}
