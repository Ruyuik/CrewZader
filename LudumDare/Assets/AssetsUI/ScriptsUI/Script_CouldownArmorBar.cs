﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_CouldownArmorBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Slider>().value = gameObject.GetComponent<Slider>().value - 0.005f;

        if (gameObject.GetComponent<Slider>().value <= 0)
        {
            transform.parent.GetComponent<Script_ArmorBar>().DisableShield(1);
            RefillCouldownBar();
        }

        if (transform.parent.GetComponent<Slider>().value == 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void RefillCouldownBar()
    {
        gameObject.GetComponent<Slider>().value = 1;
    }
}
