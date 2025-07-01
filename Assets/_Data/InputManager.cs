using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour 
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected InputActionAsset inputActions;
    [SerializeField] protected InputAction moveAction;
    [SerializeField] protected Vector2 moveAmt;

    private void OnEnable()
    {
        this.inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        this.inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 InputManager are allowed");
        InputManager.instance = this;

        this.moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        this.moveAmt = this.moveAction.ReadValue<Vector2>();
    }
}
