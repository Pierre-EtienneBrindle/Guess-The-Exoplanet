using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 15f, -0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -15f/50f/50f, 0);
    }
}