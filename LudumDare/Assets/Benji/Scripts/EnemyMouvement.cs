using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouvement : MonoBehaviour {

    public float slowSpeed;

    float start_LerpTimer;
    float lerpTimer;
    bool lerpTime;

    public float distToTarget;

    EnnemisPatternBehavior my_targetList;
    List<GameObject> enemy_NavPoints = new List<GameObject>();

    Vector3 targetPos;

	void Start () {
        my_targetList = GameObject.FindObjectOfType<EnnemisPatternBehavior>();

        if (targetPos == null)
        {
            targetPos = my_targetList.enemy_NavSpawn[Random.Range(0, my_targetList.enemy_NavSpawn.Count-1)].transform.position;
        }

        if (gameObject.name == "Shooter")
        {
            enemy_NavPoints = my_targetList.enemy_Nav;
        }
        else if (gameObject.name == "Bomber")
        {
            enemy_NavPoints = my_targetList.enemy_Nav;
        }
        else if (gameObject.name == "Lazer")
        {
            enemy_NavPoints = my_targetList.enemy_Nav;
        }
        else { enemy_NavPoints = my_targetList.enemy_Nav; }


    }

    // Update is called once per frame
    void Update()
    {
        if (targetPos != null)
        {
            distToTarget = Vector3.Distance(transform.position, targetPos);
            if (distToTarget > 0.5f)
            {
                LerpToPoint(targetPos);
            }
            else if (distToTarget <= 0.5f)
            {
                lerpTime = false;
                ChooseNewTarget();

            }

        }
    }

    void LerpToPoint(Vector3 destination)
    {

        if (!lerpTime)
        {
            lerpTime = true;
            start_LerpTimer = Time.time;

        }

        lerpTimer = Time.time - start_LerpTimer;

        transform.position = Vector3.Lerp(transform.position, destination, lerpTimer / slowSpeed);



    }

    void ChooseNewTarget()
    {

        targetPos = enemy_NavPoints[Random.Range(0, enemy_NavPoints.Count - 1)].transform.position;
    }
}
