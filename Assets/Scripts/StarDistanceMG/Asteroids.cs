using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroids : Obstacle
{
    private Rigidbody2D rb;
    private Distance text;
    private float angularSpeed;

    private void Awake()
    {
        angularSpeed = Random.Range(0, 5f);
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(rb.position.x, rb.position.y, -1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -1f*(float)(this.speed));
        rb.rotation += angularSpeed;
        if (this.transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // SPACESHIP TOUCHÉ RAAAAAH GAME OVER -1 VIE JSP MOI
        if (collision.collider.CompareTag("SpaceShip SDMG")) { 
            Destroy(gameObject);
            if (text == null)
            {
                text = GameObject.FindWithTag("Distance").GetComponent<Distance>();
            }
            text.redColor = 255;
            text.error += text.incrementation * 100f * Random.Range(1,2); // 2 sec of penalty
        }
    }
}
