using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float xlimit;
    Vector3 start_Visible;
    Vector3 end_Visible;
    public float plansSpeed;

    public List<GameObject> level_Plans; ///= new List<GameObject>();
    public List<GameObject> level_LastSpritePlans;// = new List<GameObject>();
    public List<GameObject> level_SpritePlans; // = new List<GameObject>();

    public List<Sprite> Panel1_List = new List<Sprite>();
    public List<Sprite> Panel2_List = new List<Sprite>();
    public List<Sprite> Panel3_List = new List<Sprite>();
    public List<Sprite> Panel4_List = new List<Sprite>();

    Sprite selectedSprite;

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            level_Plans.Add(transform.GetChild(i).gameObject);
            level_SpritePlans.Add(level_Plans[i].transform.GetChild(0).gameObject);
        }
    }

    private void Start()
    {
        start_Visible = new Vector3(xlimit, 0, 0);
        end_Visible = new Vector3(-xlimit, 0, 0);
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
            if (level_SpritePlans[0].transform.position.x <= 0)
            {
                GameObject my_newPlan = Instantiate(level_SpritePlans[i].gameObject, level_SpritePlans[0].transform.parent.position + start_Visible, Quaternion.identity);
                my_newPlan.transform.SetParent(level_SpritePlans[0].transform.parent);
                if (i == 0)
                {
                    selectedSprite = Panel1_List[Random.Range(0, Panel1_List.Count)];
                }
                else if (i == 1)
                {
                    selectedSprite = Panel2_List[Random.Range(0, Panel2_List.Count)];
                }
                else if (i == 2)
                {
                    selectedSprite = Panel3_List[Random.Range(0, Panel3_List.Count)];
                }
                else if (i == 3)
                {
                    selectedSprite = Panel4_List[Random.Range(0, Panel4_List.Count)];
                }
                my_newPlan.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                selectedSprite = null;
                level_LastSpritePlans.Add(level_SpritePlans[0]);
                level_SpritePlans.Remove(level_SpritePlans[0]);
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
