using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInventory : InventoryHolder
{
    public InventoryItem selectedItem;
    public InventoryItem[] hotbarItems = new InventoryItem[9];
    MyInputActions inputActions;

    #region OnEnable/OnDisable
    void OnEnable()
    {
        InputManager.Instance.inputActions.Game.Inventory.performed += ctx => UIManager.instance.OpenChestUI(inventory);
        // inputActions.Player.btn1.performed += ctx => SelectItem(0);
        // inputActions.Player.btn2.performed += ctx => SelectItem(1);
        // inputActions.Player.btn3.performed += ctx => SelectItem(2);
        // inputActions.Player.btn4.performed += ctx => SelectItem(3);
        // inputActions.Player.btn5.performed += ctx => SelectItem(4);
        // inputActions.Player.btn6.performed += ctx => SelectItem(5);
        // inputActions.Player.btn7.performed += ctx => SelectItem(6);
        // inputActions.Player.btn8.performed += ctx => SelectItem(7);
        // inputActions.Player.btn9.performed += ctx => SelectItem(8);
        // SetHotbarItems();
    }
    void OnDisable()
    {
        InputManager.Instance.inputActions.Game.Inventory.performed -= ctx => UIManager.instance.OpenChestUI(inventory);
        // inputActions.Player.btn1.performed -= ctx => SelectItem(0);
        // inputActions.Player.btn2.performed -= ctx => SelectItem(1);
        // inputActions.Player.btn3.performed -= ctx => SelectItem(2);
        // inputActions.Player.btn4.performed -= ctx => SelectItem(3);
        // inputActions.Player.btn5.performed -= ctx => SelectItem(4);
        // inputActions.Player.btn6.performed -= ctx => SelectItem(5);
        // inputActions.Player.btn7.performed -= ctx => SelectItem(6);
        // inputActions.Player.btn8.performed -= ctx => SelectItem(7);
        // inputActions.Player.btn9.performed -= ctx => SelectItem(8);
        // inputActions.Disable();
    }
    #endregion

    void Awake()
    {
        // inputActions = new InputSystem_Actions();
        // inputActions.Player.Enable();

        inventory = new Inventory<InventoryItem>(10);
    }

    void SetHotbarItems()
    {

    }

    void SelectItem(int index)
    {

    }
}
