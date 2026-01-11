using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public MyInputActions inputActions;

    private void Awake()
    {
        if (InputManager.Instance) Destroy(this);
        else InputManager.Instance = this;

        DontDestroyOnLoad(gameObject);

        inputActions = new MyInputActions();

        inputActions.Enable();
    }

    void OnDestroy()
    {
        inputActions.Disable();
        inputActions.Dispose();
    }

    public Vector2 GetMovementInput()
    {
        Vector2 movement = inputActions.Game.Move.ReadValue<Vector2>();
        movement.Normalize();
        return movement;
    }

    internal Vector3 GetMousePosition()
    {
        Vector2 mousePos = inputActions.WorldInventory.MousePosition.ReadValue<Vector2>();
        return new Vector3(mousePos.x, mousePos.y, 0);
    }
}
