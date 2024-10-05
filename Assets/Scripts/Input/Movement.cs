using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    PlayerInput.SpaceShipActions SpaceShipInput;
    // Start is called before the first frame update
    void Start()
    {
        SpaceShipInput = InputManager.Instance.GetSpaceShipActions();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = SpaceShipInput.Movement.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, 0, input.y);
        //SpaceShipInput.Move(movement * Time.deltaTime);
    }
}
