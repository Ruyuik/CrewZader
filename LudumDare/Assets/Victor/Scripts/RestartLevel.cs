using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour {

	public void Restart()
    {
        Time.timeScale = 1;
        int currentLevel = Application.loadedLevel;
        Application.LoadLevel(currentLevel);
    }
}
