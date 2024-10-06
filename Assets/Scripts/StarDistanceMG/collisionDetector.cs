using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
    CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        characterController.detectCollisions = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D obstacle)
    {
        Debug.Log("l");
        if (obstacle.transform.CompareTag("Obstacle SDMG"))
        {
            Debug.Log("L");
        }
    }
}
