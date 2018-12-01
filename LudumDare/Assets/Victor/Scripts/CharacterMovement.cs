using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed;

    [Header("Dash")]
    public float dashSpeed;
    public float dashDist;


    bool isDashing;
    float startingTime;
    Vector3 targetPosition;
    Vector3 initialPosition;

    float journeyLength;
    float distCovered;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        { 
            transform.position += new Vector3(Input.GetAxis("Horizontal")*speed, 0);

            if (Input.GetButtonDown("Dash"))
            {
                Dash(new Vector3(Mathf.Sign(Input.GetAxis("Horizontal")), 0));
            }
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical") * speed);

            if (Input.GetButtonDown("Dash"))
            {
                Dash(new Vector3(0, Mathf.Sign(Input.GetAxis("Vertical"))));
            }
        }

        //CLAMP BORDERS
        if (transform.position.x <= -8)
        {
            transform.position = new Vector2(-8, transform.position.y);
        }

        if (transform.position.y >= 4.7f)
        {
            transform.position = new Vector2(transform.position.x, 4.7f);
        }

        if (transform.position.y <= -4.7f)
        {
            transform.position = new Vector2(transform.position.x, -4.7f);
        }

        if (isDashing)
        {
            distCovered = (Time.time - startingTime) * dashSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, fracJourney);
            
            if (transform.position == targetPosition)
            {
                isDashing = false;
            }
        }
    }

    public void Dash(Vector3 direction)
    {
        startingTime = Time.time;
        initialPosition = transform.position;
        targetPosition = transform.position + direction * dashDist;
        journeyLength = Vector3.Distance(targetPosition, initialPosition);

        isDashing = true;
    }
    
}