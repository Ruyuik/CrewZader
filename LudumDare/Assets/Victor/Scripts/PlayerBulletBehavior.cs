using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour {

	void Update () {
        transform.position += new Vector3(0.5f, 0);

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
	}
}
