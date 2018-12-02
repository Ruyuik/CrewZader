using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_ScoreDisplay : MonoBehaviour {

    public int score;
    public string S_Score;
    public GameObject multiplicator_Display;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ScoreUp(int score_G)
    {
        int multiplicator = multiplicator_Display.GetComponent<Script_Multiplicator>().multiplicator;
        score += score_G * multiplicator;
        S_Score = score.ToString();
        GetComponent<Text>().text = S_Score;
    }
}
