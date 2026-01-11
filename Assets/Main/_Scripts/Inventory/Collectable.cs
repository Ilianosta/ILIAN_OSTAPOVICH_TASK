using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] InventoryItemSO itemData;
    [SerializeField] int amount = 1;

    public void PickUp(GameObject collector)
    {
        if (collector.TryGetComponent<InventoryHolder>(out InventoryHolder collectorInv))
        {
            collectorInv.Inventory.AddItem(ItemFactory.CreateItem(itemData), amount);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Collector does not have an inventory component.");
        }
    }
}
