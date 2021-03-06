﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour {

    public AudioClip[] clips;
    AudioSource source;

    public void PlayClip(int i, float s = 0.05f)
    {
        source.clip = clips[i];
        source.volume = s;
        if (i == 8)
            source.pitch = 1;
        else
            source.pitch = 2;

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
