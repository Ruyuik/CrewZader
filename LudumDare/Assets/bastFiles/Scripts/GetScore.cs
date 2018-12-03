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
		Debug.Log(scoreScript);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (scoreScript != null)
		{
			score = scoreScript.playerScore;
			Debug.Log(score);
		}
			
	}

	public int GetStaticScore()
	{
		return score;
	}

	public static void setScoreTo0()
	{
		score = 0;
	}
}