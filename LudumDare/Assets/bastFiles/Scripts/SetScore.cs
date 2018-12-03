using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
	private GetScore getScoreScript;
	private Text scoreText;
	
	// Use this for initialization
	void Start ()
	{
		scoreText = GetComponent<Text>();
		getScoreScript = FindObjectOfType<GetScore>();

		scoreText.text = getScoreScript.GetStaticScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
