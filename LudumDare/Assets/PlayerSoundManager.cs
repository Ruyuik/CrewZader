using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour {

    public AudioClip[] clips;
    AudioSource source;

    public void PlayClip(int i, float s = 0.05f)
    {
        source.clip = clips[i];
        source.volume = s;
        source.Play();
    }

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
