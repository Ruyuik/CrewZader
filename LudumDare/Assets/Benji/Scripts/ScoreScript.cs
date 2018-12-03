using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {


    public int playerScore;
    public Script_Multiplicator multiScore;

    int multiplicator;


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        multiplicator = multiScore.multiplicator;

        this.GetComponent<Text>().text = playerScore.ToString();
	}

    public void AddPoints(int enemyValue)
    {


            playerScore += enemyValue * multiplicator;

    }
}
