using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Inventory<T> where T : InventoryItem
{
    public List<T> Items { get; private set; } = new List<T>();
    public int MaxCapacity { get; private set; }

    public bool IsFull => Items.Count >= MaxCapacity;

    public System.Action onInventoryChanged;

    public Inventory(int maxCapacity)
    {
        MaxCapacity = maxCapacity;
    }

    public bool AddItem(T item, int amount = 1)
    {
        var actualItems = Items.Where(i => i._name == item._name).ToList();
        var actualItem = actualItems.Find(x => x.actualAmount < x.maxStackSize);

        if (Items.Count >= MaxCapacity && actualItem == null)
        {
            Debug.LogWarning("Inventory is full!");
            return false;
        }

        if (ContainsItem(item) != null)
        {
            if (actualItem == null)
            {
                Items.Add(item);
                item.actualAmount = amount;
            }
            else
            {
                actualItem.actualAmount += amount;
            }
        }
        else
        {
            Items.Add(item);
            item.actualAmount = amount;
        }
        onInventoryChanged?.Invoke();
        return true;
    }

    public bool RemoveItem(T item, int amount = 1)
    {
        var existingItem = ContainsItem(item);
        if (existingItem != null)
        {
            if (existingItem.actualAmount >= amount)
            {
                existingItem.actualAmount -= amount;
                onInventoryChanged?.Invoke();

                if (existingItem.actualAmount <= 0)
                {
                    Items.Remove(existingItem);
                    onInventoryChanged?.Invoke();
                }
                return true;
            }
        }
        return false;
    }

    public T ContainsItem(T item)
    {
        // Debug.Log("Finding item: " + item.itemName);
        T itemFounded = Items.Find(x => x._name == item._name);
        // Debug.Log(itemFounded == null ? "Item not found" : "Item found: " + itemFounded.itemName);
        return itemFounded;
    }

    public bool HasEnough(T item, int amount)
    {
        int totalAmount = 0;
        List<T> itemsFounded = Items.FindAll(x => x._name == item._name).ToList();

        if (itemsFounded.Count == 0) return false;

        itemsFounded.ForEach(x => totalAmount += x.actualAmount);

        return totalAmount >= amount;
    }

    public int GetAmountOf(T item)
    {
        int totalAmount = 0;
        List<T> itemsFounded = Items.FindAll(x => x._name == item._name).ToList();

        if (itemsFounded.Count == 0) return 0;

        itemsFounded.ForEach(x => totalAmount += x.actualAmount);

        return totalAmount;
    }

    public void Clear()
    {
        Items.Clear();
    }
}

[System.Serializable]
public class InventoryItem
{
    public string _name;
    public Sprite sprite;
    public int maxStackSize = 1;
    public int actualAmount = 1;
    public int slotIndex = 0;

    public InventoryItem(string name, Sprite icon, int maxStack = 99)
    {
        _name = name;
        sprite = icon;
        maxStackSize = maxStack;
        actualAmount = 1;
    }
}
