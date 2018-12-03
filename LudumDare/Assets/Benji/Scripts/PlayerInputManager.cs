using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInputManager {

    public static int controllerInd = 0;

    public static void ChooseController(int index)
    {
        controllerInd = index;
    }

    public static bool ShootUp()
    {
        if (controllerInd == 0)
        {
            return Input.GetButtonUp("KeybordFire");

        }
        else if(controllerInd == 1)
        {
            return Input.GetButtonUp("ControllerFire");

        }

        return false;
    }

    public static bool Shoot()
    {
        if (controllerInd == 0)
        {
            return Input.GetButton("KeybordFire");

        }
        else if (controllerInd == 1)
        {
            return Input.GetButton("ControllerFire");

        }

        return false;
    }

    public static bool Pause()
    {
        if (controllerInd == 0)
        {
            return Input.GetButtonDown("KeybordPause");

        }
        else if (controllerInd == 1)
        {
            return Input.GetButtonDown("ControllerPause");

        }

        return false;
    }

    public static bool Dash()
    {
        if (controllerInd == 0)
        {
            return Input.GetButtonDown("KeybordDash");

        }
        else if (controllerInd == 1)
        {
            return Input.GetButtonDown("ControllerDash");

        }

        return false;
    }

    public static bool PowerShield()
    {
        if (controllerInd == 0)
        {
            return Input.GetButtonDown("KeybordBoostShield");

        }
        else if (controllerInd == 1)
        {
            return Input.GetButtonDown("ControllerBoostShield");

        }

        return false;
    }

    public static bool PowerWeapon()
    {
        if (controllerInd == 0)
        {
            return Input.GetButtonDown("KeybordBoostDamage");

        }
        else if (controllerInd == 1)
        {
            return Input.GetButtonDown("ControllerBoostDamage");

        }

        return false;
    }

    public static bool PowerDash()
    {
        if (controllerInd == 0)
        {
            return Input.GetButtonDown("KeybordBoostMove");

        }
        else if (controllerInd == 1)
        {
            return Input.GetButtonDown("ControllerBoostMove");

        }

        return false;
    }

    public static float HorizontalAxis()
    {
        if (controllerInd == 0)
        {
            return Input.GetAxis("KeybordHorizontal");

        }
        else if (controllerInd == 1)
        {
            return Input.GetAxis("ControllerHorizontal");

        }

        return 0;
    }

    public static float VerticalAxis()
    {
        if (controllerInd == 0)
        {
            return Input.GetAxis("KeybordVertical");

        }
        else if (controllerInd == 1)
        {
            return Input.GetAxis("ControllerVertical");

        }

        return 0;
    }

}
