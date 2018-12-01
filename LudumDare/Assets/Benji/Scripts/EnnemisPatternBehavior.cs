using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisPatternBehavior : MonoBehaviour {

    public List<GameObject> enemy_Nav = new List<GameObject>();
    public List<GameObject> enemy_NavFront = new List<GameObject>();
    public List<GameObject> enemy_NavBack = new List<GameObject>();
    public List<GameObject> enemy_NavSpawn = new List<GameObject>();

    void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            enemy_Nav.Add(transform.GetChild(i).gameObject);

        }
        for (int i = 0; i < enemy_Nav.Count; i++)
        {
            if (transform.GetChild(i).position.x < 4)
            {
                enemy_NavFront.Add(transform.GetChild(i).gameObject);
            }
            if (transform.GetChild(i).position.x > 4)
            {
                enemy_NavBack.Add(transform.GetChild(i).gameObject);
            }
            if (transform.GetChild(i).position.x ==8 )
            {
                enemy_NavSpawn.Add(transform.GetChild(i).gameObject);
            }
        }

    }
	

}
