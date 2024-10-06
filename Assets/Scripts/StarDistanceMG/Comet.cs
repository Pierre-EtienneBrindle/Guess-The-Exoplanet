using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Comet : Obstacle
{
    private Transform spaceShip;
    private Rigidbody2D rb;
    [SerializeField] private float angle;
    [SerializeField] private float hypotenus;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(rb.position.x, rb.position.y, -1);
    }

    private void Start()
    {
        // Create an vector of position to the player
        spaceShip = GameObject.FindWithTag("SpaceShip SDMG")?.transform;
        hypotenus = (float)Sqrt((Pow(spaceShip.position.x - this.transform.position.x, 2.0) + Pow(spaceShip.position.y - this.transform.position.y, 2)));
        angle = -1f*(float)Acos((spaceShip.position.x - this.transform.position.x) / hypotenus);
        rb.rotation = 135f + angle*180/Mathf.PI;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2((float)(this.speed * Cos(angle)), (float)(this.speed * Sin(angle)));
        if (transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // SPACESHIP TOUCHÉ RAAAAAH GAME OVER -1 VIE JSP MOI
        if (collision.collider.CompareTag("SpaceShip SDMG"))
        Destroy(gameObject);
    }
}
