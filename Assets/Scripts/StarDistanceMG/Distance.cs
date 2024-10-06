using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class Distance : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public float distance; // pc
    public float error;
    private float distanceToReach;
    public float incrementation = 500;
    [SerializeField] public float redColor;

    public void SetDistanceToReach(float distance)
    {
        distanceToReach = distance; 
        incrementation = distanceToReach / (Random.Range(5f, 8f)) * 5f / 1000f;
    }

    bool isStarted = false;

    public void StartTheTimer() => isStarted = true;
    public event Action<float> Done;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStarted)
            return;

        distance += incrementation;
        text.SetText(((int)(distance + error)).ToString() + " pc");
        if (distance > distanceToReach)
        {
            // Should be called only ONCE
            distance += error;
            Done?.Invoke(distance);
            // Debug.Log(distance + error);
            // Debug.Log(distanceToReach);
        }
        if (redColor > 0)
        {
            text.color = new Color(255f, 255f - redColor, 255f - redColor, 1);
            redColor -= 0.05f;
        }
    }
}
