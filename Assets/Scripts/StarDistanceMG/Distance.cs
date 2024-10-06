using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public float distance; // kilometers
    public float error;
    private float distanceToReach;
    public float incrementation = 500;
    [SerializeField] public float redColor;

    // Start is called before the first frame update
    void Start()
    {
        distanceToReach = 1000f;
        Debug.Log("Please insert distance between earth to exoplanet");
    }

    void Awake()
    {
        distanceToReach = 1000; // kilometers
        incrementation = distanceToReach / (Random.Range(5f, 8f)) * 5f/1000f; ; // around 25 and 40 seconds // (Random.Range(5f, 8f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(distance);
        Debug.Log(distanceToReach);
        distance += incrementation;
        text.SetText(((int)(distance + error)).ToString() + " km");
        if (distance > distanceToReach)
        {
            // distance += error;
            // Debug.Log(distance + error);
            // Debug.Log(distanceToReach);
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }
        if (redColor > 0)
        {
            text.color = new Color(255f, 255f - redColor, 255f - redColor, 1);
            redColor -= 0.05f;
        }
    }
}
