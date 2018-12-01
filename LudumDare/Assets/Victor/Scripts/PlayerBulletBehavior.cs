using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour {

    public int damages;
    public float speed;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 49;
    }

    void Update () {
        transform.position += new Vector3(0.1f, 0)*speed;

        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") == true)
        {
            other.GetComponent<EnemyHealth>().enemyHealth -= damages;

        }
        Destroy(gameObject);
    }
}
