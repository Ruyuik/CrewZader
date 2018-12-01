using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour {

    public GameObject bullet;
    public float shootingCooldown;
    bool isShooting;

    private void Update()
    {
        if (Input.GetButton("Fire1") && !isShooting)
        {
            isShooting = true;
            StartCoroutine(CoolingdDown());
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    IEnumerator CoolingdDown()
    {
        yield return new WaitForSeconds(shootingCooldown);
        isShooting = false;
    }
}
