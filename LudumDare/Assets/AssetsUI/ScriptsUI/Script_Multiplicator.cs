using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Multiplicator : MonoBehaviour {

    public int multiplicator = 0;
    public string S_Multiplicator;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (multiplicator < 2)
        {
            transform.parent.GetChild(0).GetComponent<Text>().text = "";
            transform.parent.GetChild(1).GetComponent<Text>().text = "";
        }
        else
            transform.parent.GetChild(0).GetComponent<Text>().text = "x";
        
    }

    public void AddMultiplicator()
    {
        multiplicator++;
        ShowMultiplicator();
        Vector3 scale = transform.parent.localScale;

        if (multiplicator < 40)
        {
            transform.parent.localScale += new Vector3(0.005f, 0.005f, 0.005f);
        }

        else
            transform.parent.localScale = scale;

    }
    

    public void ShowMultiplicator()
    {
        S_Multiplicator = multiplicator.ToString();
        GetComponent<Text>().text = S_Multiplicator;
    }

    public void InitiateMultiplicator()
    {
        multiplicator = 0;
        ShowMultiplicator();
        transform.parent.localScale = new Vector3(1, 1, 1);
    }
}
