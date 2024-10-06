using System.Collections;
using System.Collections.Generic;
using UnityEngine ;

public class RopeSegment : RopeBehavior
{
    [SerializeField] private float posY; // Position Y initiale
    private float time = 0;

    private void Start()
    {
        posY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveRope(posY, time);
        time += Time.deltaTime;
    }
}
