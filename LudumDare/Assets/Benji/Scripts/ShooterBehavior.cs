using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour {

    public GameObject bullet;
    public float shootingCooldown;
    bool isShooting;

    private void Update()
    {
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(CoolingdDown());
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            Instantiate(bullet, transform.position, transform.rotation);

        }
    }

    IEnumerator CoolingdDown()
    {
        yield return new WaitForSeconds(shootingCooldown);
        isShooting = false;
    }
}
