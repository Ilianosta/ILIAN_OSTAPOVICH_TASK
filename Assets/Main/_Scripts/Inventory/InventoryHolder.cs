using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    [SerializeField] string ownerId;
    protected Inventory<InventoryItem> inventory;
    public Inventory<InventoryItem> Inventory => inventory;

    void Start()
    {
        ownerId = System.Guid.NewGuid().ToString();
        LoadInventory();
    }

    void OnEnable()
    {
        inventory.onInventoryChanged += SaveInventory;
    }

    void OnDisable()
    {
        inventory.onInventoryChanged -= SaveInventory;
    }

    public void SaveInventory()
    {
        InventorySaver.Save(ownerId, inventory.ToData());
    }

    public void LoadInventory()
    {
        var data = InventorySaver.Load(ownerId);
        if (data != null)
        {
            inventory.LoadFromData(data);
        }
    }
}
