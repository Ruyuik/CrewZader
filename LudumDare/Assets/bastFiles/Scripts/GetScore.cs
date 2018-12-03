using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GetScore : MonoBehaviour
{
	public static int score;
	private ScoreScript scoreScript;
	
	// Use this for initialization
	void Start ()
	{
		scoreScript = FindObjectOfType<ScoreScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		score = scoreScript.playerScore;

			
	}

	public int GetStaticScore()
	{
		return score;
	}

	public void setScoreTo0()
	{
		score = 0;
	}
}