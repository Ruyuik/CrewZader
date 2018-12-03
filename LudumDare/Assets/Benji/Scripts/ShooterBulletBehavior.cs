using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShooterBulletBehavior : MonoBehaviour {

    public int damages;
    public float bulletSpeed;
    public int bulletInd;

    float ymodify;

    public void InitDirection() {
        switch (bulletInd)
        {
            case 0:
                ymodify = -.02f;
                break;

            case 2:
                ymodify = .02f;
                break;
        }
    }

    void Update()
    {
        transform.position += new Vector3(-0.5f * bulletSpeed, ymodify);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
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
