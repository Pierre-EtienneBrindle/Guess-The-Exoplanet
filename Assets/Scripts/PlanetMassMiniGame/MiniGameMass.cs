using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class MiniGameMass : MonoBehaviour
{
    [SerializeField]  TMP_Text textMass;
    [SerializeField]  TMP_Text textDist;
    [SerializeField]  Slider slider;
    float distance;
    float startTime;
    float searchMass;
    float vitesse = 0f;
    const float PlanetMass = 10000f;
    readonly float G = 6.6743015f * (float)Math.Pow(10,-17); // constante gravitationnel
    const float DIVISEUR =  667.4f*597.2f; // diviseur constant de la force gravité
    

    void CalculMass()
    {
        searchMass = (float)Math.Round(slider.value * distance*distance / DIVISEUR, 2);
        textMass.text = $"Mass: {searchMass} earth";
    }

    void Start()
    {
        textMass.text = "Mass: 0.00 earth";
        slider.onValueChanged.AddListener(delegate{CalculMass();});
    }

    void Bouger(float dt)
    {
        float acc = -Math.Round(G * PlanetMass / distance / distance - slider.value*1000, 2);
        distance += vitesse * dt + acc * dt * dt;
        vitesse += acc * distance;
    }

    // Update is called once per frame
    void Update()
    {
        Bouger(Time.deltaTime);
        textDist.text = $"Distance: {Math.Round(distance, 2)} Km";
    }
}
