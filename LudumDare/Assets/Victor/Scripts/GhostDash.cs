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

        sprite.sprite = player.GetComponent<SpriteRenderer>().sprite;
        sprite.color = new Vector4(1, 1, 1, 0.27f);
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
