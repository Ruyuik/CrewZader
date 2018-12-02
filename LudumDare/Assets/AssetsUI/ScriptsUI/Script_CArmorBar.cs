using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_CArmorBar : MonoBehaviour
{

    public float reloadRate;

    public void fullShield()
    {
        GetComponent<Slider>().value = GetComponent<Slider>().maxValue;
    }

    private void Update()
    {
        if (GetComponent<Slider>().value < GetComponent<Slider>().maxValue)
        {
            transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Vector4(0.5f, 0.5f, 0.5f, 1);
            GetComponent<Slider>().value += reloadRate * Time.timeScale;
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Vector4.one; 
        }
    }

}
