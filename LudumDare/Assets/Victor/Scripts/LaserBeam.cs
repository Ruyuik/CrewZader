using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour {

    public int damage;
       
	void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
            other.GetComponent<EnemyHealth>().enemyHealth -= damage;
        }
    }
}
