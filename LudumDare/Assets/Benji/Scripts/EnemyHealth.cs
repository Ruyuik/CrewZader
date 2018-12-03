using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class EnemyHealth : MonoBehaviour {

    public int enemyHealth;
    GameObject enemyManager;

    public GameObject lootCore;
    public AudioClip lastEnemy;

    bool isdead;

    public GameObject enemy_Esplosion;

   

    void Start () {
        enemyManager = GameObject.Find("EnemyManager");

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

        if (CheckLastEnemy())
        {
            GetComponent<AudioSource>().clip = lastEnemy;
            GetComponent<AudioSource>().volume = 1;
        }

		if (enemyHealth <= 0 && !isdead )
        {
            FindObjectOfType<EnnemisPatternBehavior>().destroyedEnemy++;

            isdead = true;

            float spawnLoot = Random.Range(0.0f, 1.0f);

            if (spawnLoot < 0.1f)
            {
                Instantiate(lootCore, transform.position, transform.rotation);
            }

            Instantiate(enemy_Esplosion, transform.position, Quaternion.identity);

            
            GetComponent<AudioSource>().Play();

            FindObjectOfType<Script_Multiplicator>().AddMultiplicator();

            for(int i =0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            
            GetComponent<Collider2D>().enabled = false;
        }

        if (!GetComponent<AudioSource>().isPlaying && isdead)
        {
            
            Destroy(gameObject);
        }
    }

    bool CheckLastEnemy()
    {
        int remainingEnemies = FindObjectOfType<EnnemisPatternBehavior>().enemy_ListToSpawn.Count - FindObjectOfType<EnnemisPatternBehavior>().destroyedEnemy;

        if (remainingEnemies == 1)
            return true;
        else
            return false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider);
        }

    }
}
