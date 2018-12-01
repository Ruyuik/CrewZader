using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        { 
            transform.position += new Vector3(Input.GetAxis("Horizontal")*speed, 0);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical") * speed);
        }

        //CLAMP BORDERS
        if (transform.position.x <= -8.25)
        {
            transform.position = new Vector2(-8.25f, transform.position.y);
        }

        if (transform.position.y >= 4.5)
        {
            transform.position = new Vector2(transform.position.x, 4.5f);
        }

        if (transform.position.y <= -4.5)
        {
            transform.position = new Vector2(transform.position.x, -4.5f);
        }
    }
}