using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour {

    public int enemyHealth;

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
            Instantiate(enemy_Esplosion, transform.position, Quaternion.identity);

            if (gameObject.name == "Shooter")
            {
                GameObject.Find("Score Display").GetComponent<Script_ScoreDisplay>().ScoreUp(10);
            }
            if (gameObject.name == "Bomber")
            {
                GameObject.Find("Score Display").GetComponent<Script_ScoreDisplay>().ScoreUp(20);
            }
            if (gameObject.name == "Lazer")
            {
                GameObject.Find("Score Display").GetComponent<Script_ScoreDisplay>().ScoreUp(30);
            }

            GameObject.Find("MultiplicatorDisplay").GetComponent<Script_Multiplicator>().AddMultiplicator();
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
