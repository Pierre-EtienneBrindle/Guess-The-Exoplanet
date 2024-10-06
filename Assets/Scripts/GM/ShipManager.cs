using SingletonBehavior;
using System;
using UnityEngine.UI;
using UnityEngine;

public class ShipManager : SingletonMonobehavior<ShipManager>
{
    [SerializeField] Image planetPicture;

    public void SetPlanetPicture(Sprite sprite)
        => planetPicture.sprite = sprite;
}
