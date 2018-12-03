using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLoot : MonoBehaviour {

    Vector3 TargetLerp;
    Vector3 initLerp;
    float journeyLength;
    float distCovered;
    float startingTime;
    public float lerpSpeed;

    GameObject playerCharacter;

    bool pickedUp = false ;
    bool targetReached;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            playerCharacter = other.gameObject;

            startingTime = Time.time;
            TargetLerp = other.transform.position;
            initLerp = transform.position;
            journeyLength = Vector3.Distance(initLerp, TargetLerp);

            pickedUp = true;
            
        }
    }

    private void Update()
    {
        if (pickedUp)
        { 
            distCovered = (Time.time - startingTime) * lerpSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(initLerp, TargetLerp, fracJourney);
        }

        if (transform.position == TargetLerp)
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            if (!GetComponent<AudioSource>().isPlaying)
            {
                playerCharacter.GetComponent<PlayerAbilities>().coreCount++;
                Destroy(gameObject);
            }
        }

    }
}
