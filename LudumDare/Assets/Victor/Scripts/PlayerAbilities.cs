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

    ParticleSystem shieldParticles;

    private void Start()
    {
        shieldParticles = GameObject.Find("Player_Shield").GetComponent<ParticleSystem>();
    }

    private void Update()
    {

        if (Input.GetButtonDown("BoostShield") && !buttonPressed && coreCount > 0)
        {
            buttonPressed = true;
            shieldParticles.Play();

            FindObjectOfType<Script_ArmorBar>().fullShield();
            FindObjectOfType<Script_CArmorBar>().fullShield();

            coreCount--;
            shieldBoosted = true;
        }

        if (Input.GetButtonDown("BoostDamage") && !buttonPressed && coreCount > 0)
        {
            buttonPressed = true;
            coreCount--;

            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            attackBoosted = true;
        }

        if (Input.GetButtonDown("BoostMove") && !buttonPressed && coreCount > 0)
        {
            buttonPressed = true;
            GetComponent<CharacterMovement>().dashCount = 3;
            dashCountSlider.value = 3;
            coreCount--;

            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);

            dashBoosted = true;
        }

        if (dashCountSlider.value < 1)
        {
            dashCountSlider.value += dashReload;
            if (dashBoosted)
            {
                dashBoosted = !dashBoosted;
            }
        }
        else if (dashCountSlider.value > 1 && !dashBoosted)
        {
            dashCountSlider.value = 1;
            GetComponent<CharacterMovement>().dashCount = 1;
        }

        UpdateCoreText();
    }

    void UpdateCoreText()
    {
        coreTextDisplay.text = coreCount.ToString();
        buttonPressed = false;
    }
}
