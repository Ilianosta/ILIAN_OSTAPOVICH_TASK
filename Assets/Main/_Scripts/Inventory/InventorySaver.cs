using System.Collections.Generic;
using UnityEngine;

public static class InventorySaver
{
    public static void Save(string inventoryId, InventoryData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString($"INV_{inventoryId}", json);
    }

    public static InventoryData Load(string inventoryId)
    {
        string key = $"INV_{inventoryId}";
        if (!PlayerPrefs.HasKey(key)) return null;

        return JsonUtility.FromJson<InventoryData>(PlayerPrefs.GetString(key));
    }
}

[System.Serializable]
public class InventoryItemData
{
    public string itemId;
    public int amount;
    public int slotIndex;
}

[System.Serializable]
public class InventoryData
{
    public List<InventoryItemData> items = new();
}
