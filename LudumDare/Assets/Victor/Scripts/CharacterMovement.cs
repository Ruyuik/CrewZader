using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class CharacterMovement : MonoBehaviour {

    public float speed;

    [Header("Dash")]
    public float dashSpeed;
    public float dashDist;
    public GameObject dashFX;
    public int dashCount;
    public GameObject ghost;

    bool isDashing;
    float startingTime;
    Vector3 targetPosition;
    Vector3 initialPosition;

    float journeyLength;
    float distCovered;

    GameObject Canon_Socket;
    GameObject Thruster_Socket;

    AudioSource audioSourceComponent;

    

    private void Start()
    {
        audioSourceComponent = GetComponent<AudioSource>();
        Canon_Socket = transform.GetChild(1).gameObject;
        Thruster_Socket = transform.GetChild(0).gameObject;
    }

    private void Update()
    { 
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed, 0);
            if (Input.GetAxis("Horizontal") > 0)
                Thruster_Socket.transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
            else if (Input.GetAxis("Horizontal") < 0)
                Thruster_Socket.transform.GetChild(0).localScale = new Vector3(-0.2f, 1, 1);
        }
        else
        {
            Thruster_Socket.transform.GetChild(0).localScale = new Vector3(-0.5f, 1, 0.5f);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical") * speed);
        }

        #region DASH
        if (Input.GetButtonDown("Dash") && !isDashing && dashCount != 0)
        {
            dashCount--;
            float hDirection;
            if (Input.GetAxis("Horizontal") != 0)
                hDirection = Mathf.Sign(Input.GetAxis("Horizontal"));
            else
                hDirection = 0;

            float vDirection;
            if (Input.GetAxis("Vertical") != 0)
                vDirection = Mathf.Sign(Input.GetAxis("Vertical"));
            else
                vDirection = 0;

            Dash(new Vector3(hDirection, vDirection));
            GetComponent<PlayerAbilities>().dashCountSlider.value = dashCount;
        }
        #endregion

        #region CLAMP BORDERS
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
        #endregion

        //COMPUTE DASH
        if (isDashing && targetPosition != null && initialPosition != null)
        {
            distCovered = (Time.time - startingTime) * dashSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, fracJourney);
            
            if (transform.position == targetPosition)
            {
                isDashing = false;
            }
            else
            {
                Instantiate(ghost, transform.position, transform.rotation);
                audioSourceComponent.volume = 0.05f;
                audioSourceComponent.Play();
            }
        }
    }

    public void Dash(Vector3 direction)
    {
        startingTime = Time.time;
        initialPosition = transform.position;
        targetPosition = transform.position + direction * dashDist;
        if (targetPosition.x <= -8f)
        {
            targetPosition = new Vector3(-8f, targetPosition.y);
        }
        if (targetPosition.y >= 4.7f)
        {
            targetPosition = new Vector2(targetPosition.x, 4.7f);
        }

        if (targetPosition.y <= -4.7f)
        {
            targetPosition = new Vector2(targetPosition.x, -4.7f);
        }

        journeyLength = Vector3.Distance(targetPosition, initialPosition);

        isDashing = true;
    }
}