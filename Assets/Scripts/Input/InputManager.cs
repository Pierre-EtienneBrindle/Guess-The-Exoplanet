using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonBehavior;

public class InputManager : SingletonMonobehavior<InputManager>
{
    PlayerControl controls;
    protected override void Awake()
    {
        base.Awake();   
        controls = new PlayerControl();
    }

    public PlayerControl.SpaceShipActions GetSpaceShipActions()
    {
        controls.SpaceShip.Enable();
        return controls.SpaceShip;
    }
}