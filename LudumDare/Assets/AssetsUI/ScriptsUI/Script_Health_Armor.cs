using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Health_Armor : MonoBehaviour {

    public GameObject player;
    public GameObject multiplicatorDisplay;

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
        if (transform.GetChild(2).GetComponent<Slider>().value > 0)
        {
            transform.GetChild(2).GetComponent<Slider>().value = transform.GetChild(2).GetComponent<Slider>().value - damage;
            transform.GetChild(2).GetChild(0).GetComponent<Script_CouldownArmorBar>().RefillCouldownBar();
        }

        else if (transform.GetChild(1).GetComponent<Slider>().value > 0)
        {
            transform.GetChild(1).GetComponent<Slider>().value = transform.GetChild(1).GetComponent<Slider>().value - damage;
        }

        else
            transform.GetChild(0).GetComponent<Slider>().value = transform.GetChild(0).GetComponent<Slider>().value - damage;

        multiplicatorDisplay.GetComponent<Script_Multiplicator>().InitiateMultiplicator();
        StartCoroutine (Invincibility());
    }

    IEnumerator Invincibility()
    {
        player.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        player.GetComponent<Collider2D>().enabled = true;
    }
}
