using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class PlayerHealth : MonoBehaviour
{
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    bool anounceMade = false;
    float playerHealth;

    float tempValue = 1;

    public bool isdead;
    
    public GameObject ButtonWrapper;

    public GameObject player_Explosion;

    // Update is called once per frame
    void Update()
    {
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

        playerHealth = FindObjectOfType<Script_Health_Armor>().transform.GetChild(0).GetComponent<Slider>().value;

        

        if (playerHealth <= 0 && !isdead)
        {
            isdead = true;
            Instantiate(player_Explosion, transform.position, Quaternion.identity);

            GetComponent<PlayerSoundManager>().PlayClip(2);

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        if (isdead)
        {
            Application.LoadLevel(4);
            ToggleRestartMenu();

            GamePad.SetVibration(playerIndex, 0.0f, 0.0f);

            Time.timeScale = 0;

            if (!GetComponent<AudioSource>().isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }

    public void LostShield(GameObject caller)
    {
        float newValue = caller.GetComponent<Slider>().value;
        if(tempValue > newValue)
            GetComponent<PlayerSoundManager>().PlayClip(1, .1f);

        tempValue = newValue;
    }

    public void LostHealth()
    {
        GetComponent<PlayerSoundManager>().PlayClip(3);
    }

    public void ToggleRestartMenu()
    {
        for(int i =0; i < ButtonWrapper.transform.childCount; i++)
        {
            ButtonWrapper.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
