using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth;

    bool isdead;

    public ParticleSystem player_Explosion;



    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && isdead)
        {
            isdead = true;
            Instantiate(player_Explosion, transform.position, Quaternion.identity);

            Destroy(gameObject,0.5f);
        }
    }


}
