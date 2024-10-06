using System.Collections;
using System.Collections.Generic;
using UnityEngine ;
using A = UnityEngine.Random;

public class RopeSegment : RopeBehavior
{


    // Update is called once per frame
    void FixedUpdate()
    {
        MoveRope(transform.position.y);
    }
}
