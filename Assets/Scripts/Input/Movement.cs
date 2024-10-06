using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;

    PlayerInput.SpaceShipActions SpaceShipInput;

    //Vector3 movement = new(0, 0, 0);

    [SerializeField] float generalSpeedX;
    [SerializeField] float generalSpeedY;
    private readonly float limitX = 8.5f;
    private readonly float limitY = 4.5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpaceShipInput = InputManager.Instance.GetSpaceShipActions();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = SpaceShipInput.Movement.ReadValue<Vector2>();
        Vector3 move = new(0f, 0f, 0f);
        //Vector3 speed = new(movement.x + input.x, movement.y + input.y, 0);
        //movement.x += input.x;
        //movement.y += input.y;
        if (!(characterController.transform.position.x + (Time.deltaTime * input.x * generalSpeedX) <= -limitX || characterController.transform.position.x + (Time.deltaTime * input.x * generalSpeedX) >= limitX))
        {
            move.x = input.x * generalSpeedX;
        }
        if (!(characterController.transform.position.y + (Time.deltaTime * input.y * generalSpeedY) <= -limitY || characterController.transform.position.y + (Time.deltaTime * input.y * generalSpeedY) >= limitY)) 
        {
            move.y = input.y * generalSpeedY;
        }

        characterController.Move(Time.deltaTime * move);

        //Vector3 physicSpeed = createMovement(speed, 0.0f);
        //movement.x = physicSpeed.x;
        //movement.y = physicSpeed.y;
    }

    private void OnDisable()
    {

    }

    // Fonction qui gere le mouvement sous forme de speed
    // Vector3 createMovement(Vector3 inp, float antiForce) {
    //    Vector3 spd = new(inp.x * (antiForce/100.0f), inp.y * (antiForce / 100.0f), 0);
    //    return spd;
    //}
}
