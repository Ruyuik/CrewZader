using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostSliderBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Slider>().value = 1;
    }

    void Update()
    {
        if (GetComponent<Slider>().value <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
