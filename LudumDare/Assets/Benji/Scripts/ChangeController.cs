using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeController : MonoBehaviour
{

    public void SelectController(int index)
    {
        PlayerInputManager.ChooseController(index);

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
