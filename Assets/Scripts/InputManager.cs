using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;
    private InputSystem_Actions playerControls;

    void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        playerControls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool IsPlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }

    public bool IsAttackPressedThisFrame()
    {
        return playerControls.Player.Attack.WasPressedThisFrame();
    }

    public bool IsAttackReleasedThisFrame()
    {
        return playerControls.Player.Attack.WasReleasedThisFrame();
    }
}
