using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehavior : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void MoveRope(float y, float time) {
        Debug.Log(0.025f * Mathf.Sin((float)(time * y * 2)));
        transform.position = new Vector3(0.025f * Mathf.Sin((float)(time * y * 2)), y, transform.position.z);
    }
}
