using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1f;
    

    public Vector2 minBounds;
    public Vector2 maxBounds; 
    
   

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position; 

        if (Input.GetKey(KeyCode.A))
        {
            position.x -=  speed * Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x +=  speed * Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            position.y += speed * Time.deltaTime;
        }
        

        //clamp the new position to the defined borders 
        position.x = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        position.y = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);
        

        transform.position = position;
    }
    
}

