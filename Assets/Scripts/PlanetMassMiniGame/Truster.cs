using System.Collections;
using static System.Math;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Truster : MonoBehaviour
{
    [SerializeField] public TMP_Text text;
    Slider slider;


    public void ModText()
    {
        text.text = $"Thruster: {Round(slider.value*60, 2)} kN";
    }
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate{ModText();}); 
        text.text = $"Thruster: 0 N";
    }
}
