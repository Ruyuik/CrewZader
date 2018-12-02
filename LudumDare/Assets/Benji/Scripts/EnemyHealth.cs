using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int enemyHealth;

    public GameObject lootCore;

    bool isdead;

    public GameObject enemy_Esplosion;

	void Start () {
		if (gameObject.name == "Shooter")
        {
            enemyHealth = 10;
        }
        if (gameObject.name == "Bomber")
        {
            enemyHealth = 10;
        }
        if (gameObject.name == "Lazer")
        {
            enemyHealth = 10;
        }

    }
	
	// Update is called once per frame
	void Update () {

		if (enemyHealth <= 0 && !isdead )
        {
            isdead = true;

            float spawnLoot = Random.Range(0.0f, 1.0f);

            if (spawnLoot < 0.1f)
            {
                Instantiate(lootCore, transform.position, transform.rotation);
            }

            Instantiate(enemy_Esplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider);
        }

    }
}
