using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehavior : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void MoveRope(float y) {
        Debug.Log(0.025f * Mathf.Sin((float)(Time.deltaTime * (y))));
        transform.position = new Vector3(0.025f * Mathf.Sin((float)(Time.deltaTime * (y))), y, transform.position.z);
    }
}