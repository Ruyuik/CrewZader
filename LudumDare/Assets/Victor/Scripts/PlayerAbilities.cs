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

    [Header("Dash boost")]
    public Slider dashCountSlider;
    public float dashReload;
    bool dashBoosted = false;

    [Header("Damage boost")]
    float endingTime;
    bool attackBoosted = false;
    ParticleSystem laserBeamParticles;
    ParticleSystem laserParticles;
    public GameObject laserBeam;

    [Header("Shield boost")]
    bool shieldBoosted = false;

    float emptyingRate = 0.005f;
    float multiplyRate = 1;

    bool buttonPressed;

    public Slider shieldSlider;
    public Slider damageSlider;
    public Slider dashSlider;

    ParticleSystem shieldParticles;

    GameObject constantArmor;
    GameObject boostedArmor;

    private void Start()
    {
        laserParticles = laserBeam.GetComponent<ParticleSystem>();
        shieldParticles = GameObject.Find("Player_Shield").GetComponent<ParticleSystem>();
        laserBeamParticles = GameObject.Find("LaserPowerUp").GetComponent<ParticleSystem>();

        constantArmor = FindObjectOfType<Script_CArmorBar>().gameObject;
        boostedArmor = FindObjectOfType<Script_ArmorBar>().gameObject;
    }

    private void Update()
    {
        if (dashBoosted && attackBoosted && shieldBoosted)
            multiplyRate = 3;
        else if ((dashBoosted && attackBoosted) || (dashBoosted && shieldBoosted) || (attackBoosted && shieldBoosted))
            multiplyRate = 2;
        else
            multiplyRate = 1;

        shieldSlider.value -= emptyingRate * multiplyRate * Time.timeScale;
        damageSlider.value -= emptyingRate * multiplyRate * Time.timeScale;
        dashSlider.value -= emptyingRate * multiplyRate * Time.timeScale;

        #region Boost Shield
        if (PlayerInputManager.PowerShield() && !buttonPressed && coreCount > 0)
        {
            buttonPressed = true;
            shieldParticles.Play();

            FindObjectOfType<Script_ArmorBar>().fullShield();
            FindObjectOfType<Script_CArmorBar>().fullShield();

            coreCount--;
            shieldBoosted = true;
            shieldSlider.gameObject.SetActive(true);

            GetComponent<PlayerSoundManager>().PlayClip(4);
        }

        if (boostedArmor.GetComponent<Slider>().value == 0 && shieldBoosted)
        {
            shieldBoosted = !shieldBoosted;
            shieldParticles.Stop();
            GetComponent<PlayerSoundManager>().PlayClip(5);
        }

        if (shieldBoosted)
        {
            GameObject.Find("Shield_Couldown_Bar").GetComponent<Slider>().value = GameObject.Find("Shield_Couldown_Bar").GetComponent<Slider>().value - (emptyingRate * Time.timeScale * multiplyRate);
        }
        #endregion

        #region Boost Damage
        if (PlayerInputManager.PowerWeapon() && !buttonPressed && coreCount > 0 && !attackBoosted)
        {
            buttonPressed = true;
            coreCount--;

            transform.GetChild(4).gameObject.SetActive(false);
            damageSlider.gameObject.SetActive(true);
            laserBeamParticles.Play();

            ParticleSystem.MainModule mainLaserParticles = laserParticles.main;
            mainLaserParticles.simulationSpeed = 100f;

            attackBoosted = true;

            GetComponent<PlayerSoundManager>().PlayClip(7);
            StartCoroutine(PoweringUp());
        }

        if (attackBoosted)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }


        #endregion

        #region Boost Move
        if (PlayerInputManager.PowerDash() && !buttonPressed && coreCount > 0)
        {
            buttonPressed = true;
            GetComponent<CharacterMovement>().dashCount = 3;
            dashCountSlider.value = 3;
            coreCount--;

            transform.GetChild(4).gameObject.SetActive(false);

            dashSlider.gameObject.SetActive(true);

            dashBoosted = true;
            GetComponent<PlayerSoundManager>().PlayClip(6);
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

        if (dashBoosted)
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
        #endregion

        UpdateCoreText();
    }

    public void StopLaser()
    {
        if (attackBoosted)
        {
            Destroy(transform.Find("Lazer(Clone)").gameObject);
            attackBoosted = false;
        }
    }

    IEnumerator PoweringUp()
    {
        yield return new WaitForSeconds(.5f);
        laserBeamParticles.Stop();
        Instantiate(laserBeam, transform);
    }

    void UpdateCoreText()
    {
        coreTextDisplay.text = coreCount.ToString();
        buttonPressed = false;
    }
}
