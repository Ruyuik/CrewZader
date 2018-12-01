using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour {

    public GameObject bullet;
    public float shootingCooldown;
    bool isShooting;

    Vector3 canonPosition;

    private void Update()
    {
        canonPosition = GameObject.Find("Canon").transform.position;

        if (Input.GetButton("Fire1") && !isShooting)
        {
            isShooting = true;
            StartCoroutine(CoolingdDown());
            Instantiate(bullet, canonPosition, transform.rotation);
        }
    }

    IEnumerator CoolingdDown()
    {
        yield return new WaitForSeconds(shootingCooldown);
        isShooting = false;
    }
}
