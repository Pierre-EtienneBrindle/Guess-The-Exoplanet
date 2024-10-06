using UnityEngine;
using UnityEngine.UI;
using static System.Math;
using TMPro;


public class MiniGameMass : MonoBehaviour
{
    [SerializeField] TMP_Text textMass;
    [SerializeField] TMP_Text textDist;
    [SerializeField] TMP_Text textThruster;
    [SerializeField] TMP_Text textTempo;
    [SerializeField] Slider slider;
    [SerializeField] float PLANETMASS;
    [SerializeField] Image image;
    float searchMass;
    float acc;
    int THRUSTER;
    float distance = 25000f; // 25 Km
    float EARTHMASS = 5.972f * (float)Pow(10,24); // mass of earth
    readonly float G = 6.6743015f * (float)Pow(10,-17); // constante gravitationnel
    const float DIVISEUR =  667.4f*597.2f; // diviseur constant de la force gravité

    void Start()
    {
        textMass.text = "Mass: 0.00 earth";
        textDist.text = $"Distance: {Round(distance, 2)} m";
        textThruster.text = "Thruster: 0 N";
        PLANETMASS = 15000f * EARTHMASS;
        THRUSTER = (int)Ceiling(Random.Range(1f, 3f)*G*PLANETMASS/distance/distance);
    }

    void Bouger(float dt)
    {
        acc = -((float)Round(G * PLANETMASS / distance / distance - (float)slider.value*THRUSTER, 2));
        distance += (float)Round(acc/2*dt*dt, 2); // using it without velocity because it makes the game harder
    }

    // Update is called once per frame
    void Update()
    {
        
        Bouger(Time.deltaTime);
        textDist.text = $"Distance: {(float)Round(distance, 3)} m";
        searchMass = (float)Round(slider.value*THRUSTER * distance*distance / G / EARTHMASS);
        textMass.text = $"Mass: {searchMass} earth";
        textThruster.text = $"Thruster: {Round(slider.value*THRUSTER)} N";
        textTempo.text = $"{Round(30-Time.time)} s";
        float v = 25000f/distance;
        if (acc < 0)
        {
            image.rectTransform.localScale += Vector3.one * -acc / 10000000;
        }
        else if (acc > 0)
        {
            image.rectTransform.localScale -= Vector3.one * acc / 10000000;
        }
        if (30-Time.time < 0)
        {
            Quit();
        }
    }


    void Quit()
    {
        //revenir au vaisseau
    }
}
