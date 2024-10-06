using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public float distance; // pc
    public float error;
    private float distanceToReach;
    public float incrementation = 500;
    [SerializeField] public float redColor;

    void Awake()
    {
        Debug.Log("Please insert distance between earth to exoplanet");
        distanceToReach = 3.08567758e18f; // --|^|
        distanceToReach /= 3.08567758e16f;
        incrementation = distanceToReach/ (Random.Range(5f, 8f)) * 5f/1000f; ; // around 25 and 40 seconds // (Random.Range(5f, 8f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance += incrementation;
        text.SetText(((int)(distance + error)).ToString() + " pc");
        if (distance > distanceToReach)
        {
            // Should be called only ONCE
            distance += error;
            Debug.Log(distance + error);
            Debug.Log(distanceToReach);
        }
        if (redColor > 0)
        {
            text.color = new Color(255f, 255f - redColor, 255f - redColor, 1);
            redColor -= 0.05f;
        }
    }
}
