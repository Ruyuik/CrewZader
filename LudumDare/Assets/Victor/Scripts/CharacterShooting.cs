using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour {

    public GameObject bullet;
    public float shootingCooldown;
    bool isShooting;

    Vector3 canonPosition;

    GameObject Canon_Socket;
    GameObject Thruster_Socket;

    private void Start()
    {
        Canon_Socket = GameObject.Find("Canon");
        Thruster_Socket = GameObject.Find("Thruster");
    }

    private void Update()
    {
        canonPosition = Canon_Socket.transform.position;
        
        if (Input.GetButton("Fire1") && !isShooting)
        {
            isShooting = true;
            Canon_Socket.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
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
