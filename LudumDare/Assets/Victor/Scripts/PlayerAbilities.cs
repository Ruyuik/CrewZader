using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{

    public int coreCount = 5;
    int maxCoreCount = 10;

    public Text coreTextDisplay;
    public Text dashesTextDisplay;

    public Slider dashCountSlider;

    public float dashReload;

    bool dashBoosted = false;
    bool attackBoosted = false;
    bool shieldBoosted = false;

    bool buttonPressed;

    private void Update()
    {
        if (Input.GetButtonDown("BoostShield") && !buttonPressed && coreCount > 0)
        {
            buttonPressed = true;
            coreCount--;
            shieldBoosted = true;
        }

        if (Input.GetButtonDown("BoostDamage") && !buttonPressed && coreCount > 0)
        {
            buttonPressed = true;
            coreCount--;
            attackBoosted = true;
        }

        if (Input.GetButtonDown("BoostMove") && !buttonPressed && coreCount > 0)
        {
            buttonPressed = true;
            GetComponent<CharacterMovement>().dashCount = 3;
            dashCountSlider.value = 3;
            coreCount--;
            dashBoosted = true;
        }

        if (dashCountSlider.value < 1)
        {
            dashCountSlider.value += dashReload;
            if (dashBoosted)
            {
                dashBoosted = !dashBoosted;
            }
        }else if (dashCountSlider.value > 1 && !dashBoosted)
        {
            dashCountSlider.value = 1;
            GetComponent<CharacterMovement>().dashCount = 1;
        }

        UpdateDashes();
        UpdateCoreText();
    }

    void UpdateDashes()
    {
        dashesTextDisplay.text = GetComponent<CharacterMovement>().dashCount.ToString();
    }

    void UpdateCoreText()
    {
        coreTextDisplay.text = coreCount.ToString();
        buttonPressed = false;
    }
}
