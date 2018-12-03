using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostSliderBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Slider>().value = 1;

        if (name == "ShieldSlider")
        {
            GetComponent<Slider>().value = 4;
        }
    }

    void Update()
    {
        if (GetComponent<Slider>().value <= 0)
        {
            if (name == "DamageSlider")
            {
                FindObjectOfType<PlayerAbilities>().StopLaser();
            }
            gameObject.SetActive(false);
        }
    }

}
