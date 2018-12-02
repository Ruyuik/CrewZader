using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberBulletBehavior : MonoBehaviour {

    public GameObject fragedBullet;
    public int bulletFragment;

    public int damages;
    public float bulletSpeed;

    public int bulletInd;
    float ymodif;

    float startTimer;
    public float travelTime;
    bool startFragmentation;

    public List<Vector3> fragmentDir = new List<Vector3>();

    public void InitDirection()
    {
        if (bulletInd == 0)
        {
            ymodif = 0.02f;
        }
        else if (bulletInd == 1)
        {
            ymodif = 0;
        }
        else if (bulletInd == 2)
        {
            ymodif = -0.02f;
        }
        startTimer = Time.time;
        SetFragmentDir();
    }

    void Update()
    {
        transform.position += new Vector3(-0.1f*bulletSpeed, ymodif);
        transform.eulerAngles += new Vector3(0, 0, Random.Range(0f, 10f));
        if (startFragmentation == false)
        {
            BulletFragmentation();
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    void BulletFragmentation()
    {
        if (Time.time - startTimer >= travelTime )
        {
            startFragmentation = true;
            for(int i =0; i < bulletFragment; i++)
            {
                GameObject myNewBullet = Instantiate(fragedBullet, transform.position + fragmentDir[i], transform.rotation);
                myNewBullet.GetComponent<FraggedBomberBulletBehavior>().bulletDir = fragmentDir[i];
            }
            Destroy(gameObject);
        }

    }

    void SetFragmentDir()
    {
        for (float i = 0; i <= 360; i += 360 / bulletFragment)
        {
            fragmentDir.Add(new Vector3(Mathf.Cos(i), Mathf.Sin(i), 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            FindObjectOfType<Script_Health_Armor>().GetDamage(damages);
            Destroy(gameObject);
        }

        if (other.CompareTag("PlayerBullet") == true)
        {
            Destroy(gameObject);
        }        
    }
}
