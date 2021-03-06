﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FraggedBomberBulletBehavior : MonoBehaviour {

    public int damages;
    public float bulletSpeed;

    public Vector3 bulletDir;

	void Start () {
		
	}

    void Update()
    {
        if (bulletDir != null)
        {
            transform.position += bulletDir*bulletSpeed;
        }
        if (transform.position.x < -10 || transform.position.y < -8 || transform.position.y > 8)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 3);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            FindObjectOfType<Script_Health_Armor>().GetDamage(damages);
            Destroy(gameObject);
        }
    }
}
