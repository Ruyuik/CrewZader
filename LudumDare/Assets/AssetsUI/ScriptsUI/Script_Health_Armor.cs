using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class Script_Health_Armor : MonoBehaviour {

    public GameObject player;
    Material defaultMat;
    public Material blinkMat;

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        #region Detect Controller
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);
        #endregion

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDamage(1);
        }*/
	}

    public void GetDamage(float damage)
    {
        for(int i = 2; i < 5; i++)
        {
            if (player.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                defaultMat = player.transform.GetChild(i).GetComponent<Renderer>().material;
                player.transform.GetChild(i).GetComponent<Renderer>().material = blinkMat;
                break;
            }
        }

        if (transform.GetChild(2).GetComponent<Slider>().value > 0 && transform.GetChild(2).GetComponent<Slider>().value % 1 == 0)
        {
            transform.GetChild(2).GetComponent<Slider>().value = transform.GetChild(2).GetComponent<Slider>().value - damage;
            transform.GetChild(2).GetChild(0).GetComponent<Script_CouldownArmorBar>().RefillCouldownBar();
        }

        else if (transform.GetChild(1).GetComponent<Slider>().value > 0 && transform.GetChild(1).GetComponent<Slider>().value % 1 == 0)
        {
            transform.GetChild(1).GetComponent<Slider>().value = transform.GetChild(1).GetComponent<Slider>().value - damage;
        }

        else
            transform.GetChild(0).GetComponent<Slider>().value = transform.GetChild(0).GetComponent<Slider>().value - damage;

        StartCoroutine (Invincibility());
    }

    IEnumerator Invincibility()
    {
        GamePad.SetVibration(playerIndex, 1.0f, 1.0f);
        player.GetComponent<Collider2D>().enabled = false;
        for (int i = 2; i < 5; i++)
        {
            if (player.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player.transform.GetChild(i).GetComponent<Renderer>().material = blinkMat;
                break;
            }
        }
        yield return new WaitForSeconds(.25f);
        for (int i = 2; i < 5; i++)
        {
            if (player.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player.transform.GetChild(i).GetComponent<Renderer>().material = defaultMat;
                break;
            }
        }
        GamePad.SetVibration(playerIndex, 0.0f, 0.0f);
        yield return new WaitForSeconds(.25f);
        for (int i = 2; i < 5; i++)
        {
            if (player.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player.transform.GetChild(i).GetComponent<Renderer>().material = blinkMat;
                break;
            }
        }
        yield return new WaitForSeconds(.25f);
        for (int i = 2; i < 5; i++)
        {
            if (player.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player.transform.GetChild(i).GetComponent<Renderer>().material = defaultMat;
                break;
            }
        }
        player.GetComponent<Collider2D>().enabled = true;
    }
}
