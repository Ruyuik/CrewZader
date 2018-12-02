using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_CArmorBar : MonoBehaviour {
    
    public void fullShield()
    {
        GetComponent<Slider>().value = GetComponent<Slider>().maxValue;
    }

}
