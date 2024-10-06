using System.Collections;
using System.Collections.Generic;
using UnityEngine ;

public class RopeSegment : RopeBehavior
{
    [SerializeField] private float posX; // Position X initiale
    [SerializeField] private float posY;
    private float time = 0;
    [SerializeField] private float offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        MoveRope(posX, posY, time, offset);
        time += Time.deltaTime;
    }
}
