using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;

    PlayerInput.SpaceShipActions SpaceShipInput;

    public float generalSpeed = 10;

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
        Vector3 speed = new(input.x, input.y, 0);

        characterController.Move(Time.deltaTime * generalSpeed * speed);
    }

    private void OnDisable()
    {

    }

    Vector3 spacePhysics(Vector3 speed) {
        Vector3 spaceSpeed = new(0, 0, 0);
        return spaceSpeed;
    }

    Vector3 createMovement(Vector2 inp, float genSpeed, float antiForce) {
        
        Vector3 spaceMovement = spacePhysics(inp);
        //Debug.Log(speed.x);
        Debug.Log(spaceMovement.x);
        return spaceMovement;
    }
}
