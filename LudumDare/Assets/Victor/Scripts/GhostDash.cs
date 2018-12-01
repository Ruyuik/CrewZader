using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDash : MonoBehaviour {

    SpriteRenderer sprite;
    GameObject player;
    float timer = .5f;
    

    private void Start()
    {
        player = GameObject.Find("PlayerCharacter");

        sprite = GetComponent<SpriteRenderer>();

        transform.position = player.transform.position;
        transform.localScale = player.transform.localScale;

        for(int i = 2; i<player.transform.childCount; i++)
        {
            if (player.transform.GetChild(i).gameObject.active)
            {
                sprite.sprite = player.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }

        sprite.color = new Vector4(1, 1, 1, 0.25f);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (transform.localScale != Vector3.zero)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
        }

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
