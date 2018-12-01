using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDamage(1);
        }
	}

    public void GetDamage(float damage)
    {
        if (transform.GetChild(2).GetComponent<Slider>().value >= 0)
        {
            float negativeValue = transform.GetChild(0).GetComponent<Slider>().value - damage;
            transform.GetChild(1).GetComponent<Slider>().value = transform.GetChild(1).GetComponent<Slider>().value - negativeValue;
            Debug.Log("Perte de bouclier");
        }

        else if (transform.GetChild(1).GetComponent<Slider>().value >= 0)
        {
            transform.GetChild(1).GetComponent<Slider>().value = 0;
            Debug.Log("Perte de bouclier constant");
        }

        else
        {
            transform.GetChild(0).GetComponent<Slider>().value = transform.GetChild(0).GetComponent<Slider>().value - damage;
            Debug.Log("Perte de vie");
        }
    }
}
