 using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    Bounds zoneBound;

    PlayerInput.SpaceShipActions actions;
    float width; 
    float height;
    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        height = 2 * cam.orthographicSize;
        width = height * cam.aspect;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        zoneBound = box.bounds;
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
        position.x = Mathf.Clamp(position.x, zoneBound.min.x + width * .9f, zoneBound.max.x - width * .9f);
        position.y = Mathf.Clamp(position.y, zoneBound.min.y + height * .9f, zoneBound.max.y - height * .9f);

        transform.position = position;
    }
}