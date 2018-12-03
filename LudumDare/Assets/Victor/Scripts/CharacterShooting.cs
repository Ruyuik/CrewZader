using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class CharacterShooting : MonoBehaviour {

    public GameObject bullet;
    public float shootingCooldown;
    bool isShooting;

    Vector3 canonPosition;
    
    GameObject Canon_Socket;
    GameObject Thruster_Socket;

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    private void Start()
    {
        Canon_Socket = GameObject.Find("Canon");
        Thruster_Socket = GameObject.Find("Thruster");
    }

    private void Update()
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

        canonPosition = Canon_Socket.transform.position;
        
        if (PlayerInputManager.Shoot() && !isShooting)
        {
            GamePad.SetVibration(playerIndex, 0.3f, 0.0f);
            isShooting = true;
            Canon_Socket.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            StartCoroutine(CoolingdDown());
            Instantiate(bullet, canonPosition, transform.rotation);
        }

        if (PlayerInputManager.ShootUp())
        {
            GamePad.SetVibration(playerIndex, 0, 0);
        }
    }

    IEnumerator CoolingdDown()
    {
        yield return new WaitForSeconds(shootingCooldown);
        isShooting = false;
    }
}
