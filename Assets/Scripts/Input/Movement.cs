using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;

    PlayerInput.SpaceShipActions SpaceShipInput;

    Vector3 movement = new(0, 0, 0);

    [SerializeField] float generalSpeed = 10f;

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
        //Vector3 speed = new(movement.x + input.x, movement.y + input.y, 0);
        //movement.x += input.x;
        //movement.y += input.y;
        characterController.Move(Time.deltaTime * generalSpeed * input);
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
