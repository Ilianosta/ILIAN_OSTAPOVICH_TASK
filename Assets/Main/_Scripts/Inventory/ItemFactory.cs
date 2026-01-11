using UnityEngine;

public static class ItemFactory
{
    public static InventoryItem CreateItem(InventoryItemSO data)
    {
        switch (data)
        {
            default:
                return new InventoryItem(data.Name, data.sprite, data.maxStackSize);
        }
    }
}
