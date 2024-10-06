using SingletonBehavior;

public class InputManager : SingletonMonobehavior<InputManager>
{
    PlayerInput controls;
    protected override void Awake()
    {
        base.Awake();   
        controls = new PlayerInput();
        controls.GeneralActions.Enable();
    }

    public PlayerInput.SpaceShipActions GetSpaceShipActions()
    {
        DisableAllInputs();
        controls.SpaceShip.Enable();
        return controls.SpaceShip;
    }

    public PlayerInput.LimitedSpaceShipActions GetLimitedSpaceShipActions()
    {
        DisableAllInputs();
        controls.LimitedSpaceShip.Enable();
        return controls.LimitedSpaceShip;
    }

    public PlayerInput.GeneralActionsActions GetGeneralActions()
        => controls.GeneralActions;
        
    


    private void DisableAllInputs()
    {
        controls.SpaceShip.Disable();
        controls.LimitedSpaceShip.Disable();
    }
}