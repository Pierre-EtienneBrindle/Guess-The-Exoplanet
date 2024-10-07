using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retreiveData : MonoBehaviour
{
    float temperature;

    public void SetTemperature(float value) //function called when the game is started 
        => temperature = value;
}
