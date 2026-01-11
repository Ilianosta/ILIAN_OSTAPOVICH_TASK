using UnityEngine;

public class Chest : InventoryHolder, IInteractable
{
    public int capacity = 20;
    Outline outline;
    void Awake()
    {
        outline = GetComponent<Outline>();
        inventory = new Inventory<InventoryItem>(capacity);
    }

    public void OpenChest()
    {
        UIManager.instance.OpenChestUI(inventory);
    }

    public void Interact()
    {
        OpenChest();
    }

    public void Outline(bool enable)
    {
        outline.enabled = enable;
    }
}
