using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    protected Inventory<InventoryItem> inventory;
    public Inventory<InventoryItem> Inventory => inventory;
}
