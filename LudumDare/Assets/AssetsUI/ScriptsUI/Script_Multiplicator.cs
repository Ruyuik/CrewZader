using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Multiplicator : MonoBehaviour {

    public int multiplicator;
    public string S_Multiplicator;
    public bool isShit;
    public Animator animator;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddMultiplicator();
        }
    }

    public void AddMultiplicator()
    {
        multiplicator++;
        ShowMultiplicator();
        Vector3 scale = transform.parent.localScale;

        if (multiplicator < 40)
        {
            transform.parent.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        }

        else
            transform.parent.localScale = scale;
    }

    public void ShowMultiplicator()
    {
        if (multiplicator > 1)
        {
            GetComponent<Text>().enabled = true;
            transform.parent.GetChild(0).GetComponent<Text>().enabled = true;
            animator.SetInteger("Multiplicator", multiplicator);
        }

        S_Multiplicator = multiplicator.ToString();
        GetComponent<Text>().text = S_Multiplicator;
    }

    public void InitiateMultiplicator()
    {
        multiplicator = 1;
        animator.SetInteger("Multiplicator", multiplicator);
        ShowMultiplicator();
        transform.parent.localScale = new Vector3(1, 1, 1);
        isShit = false;
    }
}
