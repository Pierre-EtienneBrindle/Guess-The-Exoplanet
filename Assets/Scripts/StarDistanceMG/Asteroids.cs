using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroids : Obstacle
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(rb.position.x, rb.position.y, -1);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -1f*(float)(this.speed));
        if (this.transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }
//    private void OnTriggerEnter2D(Collider2D obstacle)
//    {
//        if (obstacle.transform.CompareTag("SpaceShip SDMG"))
//        {
//            Debug.Log("WTF IS TRIGGER > ");
//        }
//    }
}
