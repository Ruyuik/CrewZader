using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberBehavior : MonoBehaviour {

    public GameObject fragBullet;
    public GameObject bullet;
    public float shootingCooldown;
    bool isShooting;

    private void Update()
    {
        if (!isShooting)
        {
            isShooting = true;
            
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            GameObject my_bullet1 = Instantiate(bullet, transform.position, transform.rotation);
            GameObject my_bullet2 = Instantiate(fragBullet, transform.position, transform.rotation);
            GameObject my_bullet3 = Instantiate(bullet, transform.position, transform.rotation);

            my_bullet1.GetComponent<ShooterBulletBehavior>().bulletInd = 0;
            my_bullet1.GetComponent<ShooterBulletBehavior>().InitDirection();

            my_bullet2.GetComponent<BomberBulletBehavior>().bulletInd = 1;
            my_bullet2.GetComponent<BomberBulletBehavior>().InitDirection();

            my_bullet3.GetComponent<ShooterBulletBehavior>().bulletInd = 2;
            my_bullet3.GetComponent<ShooterBulletBehavior>().InitDirection();

            StartCoroutine(CoolingdDown());

        }
    }

    IEnumerator CoolingdDown()
    {
        yield return new WaitForSeconds(shootingCooldown);
        isShooting = false;
    }


}
