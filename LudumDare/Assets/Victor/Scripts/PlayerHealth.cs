using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    float playerHealth;

    bool isdead;
   public  AudioClip deathSound;

    public GameObject player_Explosion;
    
    // Update is called once per frame
    void Update()
    {
        playerHealth = FindObjectOfType<Script_Health_Armor>().transform.GetChild(0).GetComponent<Slider>().value;

        if (playerHealth <= 0 && !isdead)
        {
            isdead = true;
            Instantiate(player_Explosion, transform.position, Quaternion.identity);

            GetComponent<AudioSource>().clip = deathSound;
        }

        if (isdead && !GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }


}
