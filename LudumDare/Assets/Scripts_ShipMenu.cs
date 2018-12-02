using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts_ShipMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ShipFrequency());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShipsStrikeBack ()
    {
        StartCoroutine(ShipFrequency());
    }

    IEnumerator ShipFrequency()
    {
        yield return new WaitForSeconds(10);
        GetComponent<Animator>().Play(0);
        ShipsStrikeBack();
    }
}
