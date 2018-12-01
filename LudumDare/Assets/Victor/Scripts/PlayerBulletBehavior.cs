﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour {

    public float damages;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 50;
    }

    void Update () {
        transform.position += new Vector3(0.5f, 0);

        if (transform.position.x > 100)
        {
            Destroy(gameObject);
        }
	}
}
