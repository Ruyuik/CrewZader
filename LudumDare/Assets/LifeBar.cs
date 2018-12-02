using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

    public float currentlife { get; set; }
    public float maxLife = 3;
    public float minLife = 0;

    public Slider lifeBar;

	// Use this for initialization
	void Start () {

        currentlife = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DealDamage(1);
        }
	}

    public void DealDamage(float damageValue)
    {
        currentlife -= damageValue;

        lifeBar.value = currentlife;

        if (currentlife <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        currentlife = 0;
        Debug.Log("You Die");
        Time.timeScale = 0;
    }
}
