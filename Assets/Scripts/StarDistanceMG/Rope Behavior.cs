using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehavior : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void MoveRope(float x, float y, float time, float offset) {
        float mySin = 0.001f * (Mathf.Sin((float)(2f * time + offset + y)));
        transform.Translate(mySin, 0, 0);
    }
}