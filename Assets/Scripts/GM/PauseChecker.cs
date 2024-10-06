using UnityEngine;
using UnityEngine.InputSystem;

public class PauseChecker : MonoBehaviour
{
    PlayerInput.GeneralActionsActions actions;
    bool areActionsSet = false;

    private void Start()
    {
        actions = InputManager.Instance.GetGeneralActions();
        actions.Pause.performed -= TogglePause;
        actions.Pause.performed += TogglePause;
        areActionsSet = true;
    }

    private void OnEnable()
    {
        if(!areActionsSet)
            return;
        actions.Pause.performed -= TogglePause;
        actions.Pause.performed += TogglePause;
    }

    private void OnDisable()
    {
        actions.Pause.performed -= TogglePause;
    }

    void TogglePause(InputAction.CallbackContext ctx)
        => GameManager.Instance.TogglePause();
}
