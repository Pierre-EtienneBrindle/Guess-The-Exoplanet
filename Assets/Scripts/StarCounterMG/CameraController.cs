using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    
    [SerializeField] Vector2 minBounds;
    [SerializeField] Vector2 maxBounds;

    PlayerInput.SpaceShipActions actions;
    float width; 
    float height;
    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        height = 2 * cam.orthographicSize;
        width = height * cam.aspect;
    }

    private void Start()
    {
        actions = InputManager.Instance.GetSpaceShipActions();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        Vector2 input = speed* Time.deltaTime * actions.Movement.ReadValue<Vector2>();
        position.y += input.y;
        position.x += input.x;

        //clamp the new position to the defined borders 
        position.x = Mathf.Clamp(position.x, minBounds.x + width, maxBounds.x - width);
        position.y = Mathf.Clamp(position.y, minBounds.y + height, maxBounds.y - height);

        transform.position = position;
    }
    
}

