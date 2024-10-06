using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        text.text = distance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        distance += 50;
    }
}
