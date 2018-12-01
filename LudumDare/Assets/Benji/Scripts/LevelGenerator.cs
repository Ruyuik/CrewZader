using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    Vector3 start_Visible = new Vector3(17.7f, 0, 0);
    Vector3 end_Visible = new Vector3(-17.7f, 0, 0);
    public float plansSpeed;

    public List<GameObject> level_Plans = new List<GameObject>();
    public List<GameObject> level_LastSpritePlans = new List<GameObject>();
    public List<GameObject> level_SpritePlans = new List<GameObject>();

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            level_Plans.Add(transform.GetChild(i).gameObject);
            level_SpritePlans.Add(level_Plans[i].transform.GetChild(0).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpritePlanMove();
        SpritePlanInstantiation();
        SpritePlanDestruction();
    }

    void SpritePlanMove()
    {
        for (int i = 0; i < level_SpritePlans.Count; i++)
        {

            level_SpritePlans[i].transform.position += new Vector3(-0.1f, 0, 0) * plansSpeed * (level_SpritePlans[i].transform.parent.transform.GetSiblingIndex()+1);


        }
        for (int i = 0; i < level_LastSpritePlans.Count; i++)
        {
            level_LastSpritePlans[i].transform.position += new Vector3(-0.1f, 0, 0) * plansSpeed * (level_LastSpritePlans[i].transform.parent.transform.GetSiblingIndex() + 1);

        }
    }

    void SpritePlanInstantiation()
    {
        for (int i = 0; i < level_SpritePlans.Count; i++)
        {
            if (level_SpritePlans[i].transform.position.x <= 0)
            {
                GameObject my_newPlan = Instantiate(level_SpritePlans[i].gameObject, level_SpritePlans[i].transform.parent.position + start_Visible, Quaternion.identity);
                my_newPlan.transform.SetParent(level_SpritePlans[i].transform.parent);
                level_LastSpritePlans.Add(level_SpritePlans[i]);
                level_SpritePlans.Remove(level_SpritePlans[i]);

                level_SpritePlans.Add(my_newPlan);

            }
        }
    }

    void SpritePlanDestruction()
    {
        for (int i = 0; i < level_LastSpritePlans.Count; i++)
        {
            if (level_LastSpritePlans[i].transform.position.x <= end_Visible.x)
            {

                Destroy(level_LastSpritePlans[i]);
                level_LastSpritePlans.Remove(level_LastSpritePlans[i]);
            }

        }
    }
}
