using SingletonBehavior;

public class InputManager : SingletonMonobehavior<InputManager>
{
    PlayerInput controls;
    protected override void Awake()
    {
        base.Awake();   
        controls = new PlayerInput();
    }

    public PlayerInput.SpaceShipActions GetSpaceShipActions()
    {
        controls.SpaceShip.Enable();
        return controls.SpaceShip;
    }
}