using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour {

    public int damages;
    public float speed;

    public GameObject sparks;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 49;
        ParticleSystem.MainModule main = sparks.GetComponent<ParticleSystem>().main;
        main.simulationSpeed = 4.5f;
    }

    void Update () {
        transform.position += new Vector3(0.1f, 0)*speed;

        if (transform.position.x > 20)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                Destroy(gameObject);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy") == true)
        {
            other.collider.GetComponent<EnemyHealth>().enemyHealth -= damages;
            Instantiate(sparks, other.contacts[0].point, transform.rotation);
            transform.position = new Vector3(25, 0, 0);
        }
        
    }
}
