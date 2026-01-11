using System.Collections.Generic;
using UnityEngine;

public class UIChest : MonoBehaviour
{
    [SerializeField] GameObject uiItemPrefab;
    [SerializeField] Transform uiItemParent;

    List<UIItem> uiItems = new List<UIItem>();
    void OnEnable()
    {
        InputManager.Instance.inputActions.WorldInventory.Enable();
        InputManager.Instance.inputActions.Game.Disable();
        InputManager.Instance.inputActions.WorldInventory.Close.performed += ctx => UIManager.instance.SwitchToHotbarMode();

        UIManager.instance.SetCursorState(true);
    }

    void OnDisable()
    {
        InputManager.Instance.inputActions.WorldInventory.Disable();
        InputManager.Instance.inputActions.Game.Enable();
        InputManager.Instance.inputActions.WorldInventory.Close.performed -= ctx => UIManager.instance.SwitchToHotbarMode();

        UIManager.instance.SetCursorState(false);
    }

    public void OpenChest(Inventory<InventoryItem> inventory)
    {
        foreach (Transform child in uiItemParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < inventory.MaxCapacity; i++)
        {
            GameObject uiItemObj = Instantiate(uiItemPrefab, uiItemParent);
            UIItem uiItem = uiItemObj.GetComponent<UIItem>();

            InventoryItem item = inventory.Items.Count > i ? inventory.Items[i] : null;
            
            if (item != null)
            {
                item.slotIndex = i;
                uiItem.SetItem(item);
            }

            uiItems.Add(uiItem);
        }
    }
}