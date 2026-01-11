using UnityEngine;

public class UIChest : MonoBehaviour
{
    [SerializeField] GameObject uiItemPrefab;
    [SerializeField] Transform uiItemParent;
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

    public void OpenChest(Chest chest)
    {
        foreach (Transform child in uiItemParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < chest.capacity; i++)
        {
            GameObject uiItemObj = Instantiate(uiItemPrefab, uiItemParent);
        }
    }
}
