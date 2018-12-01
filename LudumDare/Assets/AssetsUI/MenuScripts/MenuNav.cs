using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuNav : MonoBehaviour
{
    List<Vector2> mousePositions = new List<Vector2>();
    public GameObject Options;
    public GameObject Main;
    public int Index;
    public GameObject OptionsSkin;
    public GameObject PlaySkin;
    public GameObject QuitSkin;
    private Vector2 mouseVector;


    void Update()
    {
        GetMouseVector();
        MoveCheck();



        if (Input.GetKeyDown("down"))
        {
            Index--;

            if (Index <= 0)
            {
                Index = 3;
            }

            switch (Index)
            {

                case 3:
                    PlaySkin.gameObject.SetActive(true);
                    OptionsSkin.gameObject.SetActive(false);
                    QuitSkin.gameObject.SetActive(false);
                    break;

                case 2:
                    PlaySkin.gameObject.SetActive(false);
                    OptionsSkin.gameObject.SetActive(true);
                    QuitSkin.gameObject.SetActive(false);
                    break;

                case 1:
                    PlaySkin.gameObject.SetActive(false);
                    OptionsSkin.gameObject.SetActive(false);
                    QuitSkin.gameObject.SetActive(true);
                    break;

                default:
                    PlaySkin.gameObject.SetActive(false);
                    OptionsSkin.gameObject.SetActive(false);
                    QuitSkin.gameObject.SetActive(false);
                    break;
            }
        }

        if (Input.GetKeyDown("up"))
        {
            Index++;

            if (Index >= 4)
            {
                Index = 1;
            }

            switch (Index)
            {

                case 3:
                    PlaySkin.gameObject.SetActive(true);
                    OptionsSkin.gameObject.SetActive(false);
                    QuitSkin.gameObject.SetActive(false);
                    break;

                case 2:
                    PlaySkin.gameObject.SetActive(false);
                    OptionsSkin.gameObject.SetActive(true);
                    QuitSkin.gameObject.SetActive(false);
                    break;

                case 1:
                    PlaySkin.gameObject.SetActive(false);
                    OptionsSkin.gameObject.SetActive(false);
                    QuitSkin.gameObject.SetActive(true);
                    break;

                default:
                    PlaySkin.gameObject.SetActive(false);
                    OptionsSkin.gameObject.SetActive(false);
                    QuitSkin.gameObject.SetActive(false);
                    break;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            switch (Index)
            {
                case 3:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    break;

                case 2:
                    Main.gameObject.SetActive(false);
                    Options.gameObject.SetActive(true);
                    break;

                case 1:
                    Application.Quit();
                    break;

                default:

                    break;
            }
        }

    }

    void GetMouseVector()
    {
        mousePositions.Insert(0, Input.mousePosition);

        if (mousePositions.Count >= 4)
            mousePositions.RemoveRange(3, 1);

        if (mousePositions.Count > 1)
            mouseVector = mousePositions[1] - mousePositions[0];
        else
        {
            mouseVector = new Vector2(0, 0);
        }
    }

    bool MoveCheck()
    {
        if (mouseVector != new Vector2(0, 0))
        {
            PlaySkin.gameObject.SetActive(false);
            OptionsSkin.gameObject.SetActive(false);
            QuitSkin.gameObject.SetActive(false);
            Index = 0;

            return true;
        }
        else
        {
            return false;
        }
    }
    
}