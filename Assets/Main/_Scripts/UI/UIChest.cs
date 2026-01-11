using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIChest : MonoBehaviour
{
    [SerializeField] GameObject uiItemPrefab;
    [SerializeField] Transform uiItemParent;

    List<UIItem> uiItems = new List<UIItem>();

    UIItem hoveredItem;

    void OnEnable()
    {
        InputManager.Instance.inputActions.WorldInventory.Enable();
        InputManager.Instance.inputActions.Game.Disable();
        InputManager.Instance.inputActions.WorldInventory.Close.performed += ctx => UIManager.instance.SwitchToHotbarMode();

        InputManager.Instance.inputActions.WorldInventory.Hold.performed += ctx => RayToHoverItem();

        UIManager.instance.SetCursorState(true);
    }

    void OnDisable()
    {
        InputManager.Instance.inputActions.WorldInventory.Disable();
        InputManager.Instance.inputActions.Game.Enable();
        InputManager.Instance.inputActions.WorldInventory.Close.performed -= ctx => UIManager.instance.SwitchToHotbarMode();

        UIManager.instance.SetCursorState(false);
    }

    void Update()
    {
        RayToHoverItem();
        if (hoveredItem != null)
        {
            // Debug.Log("Hovering over item: " + hoveredItem.name);
            Vector3 mousePos = InputManager.Instance.GetMousePosition();
            UIManager.instance.holdingItem.transform.position = mousePos;
            hoveredItem.OnHover();
        }
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

    void RayToHoverItem()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = InputManager.Instance.GetMousePosition()
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        foreach (RaycastResult result in results)
        {
            UIItem uiItem = result.gameObject.GetComponent<UIItem>();

            if (uiItem != null)
            {
                hoveredItem = uiItem;
                break;
            }
            else if (uiItem == null && hoveredItem != null)
            {
                UIManager.instance.hoverInfo.SetActive(false);
                hoveredItem = null;
            }
        }
    }
}