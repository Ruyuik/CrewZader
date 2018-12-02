using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_ArmorBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisableShield(float value)
    {
        GetComponent<Slider>().value = GetComponent<Slider>().value - value;
    }

    public void fullShield()
    {
        GetComponent<Slider>().value = GetComponent<Slider>().maxValue;
    }
}
