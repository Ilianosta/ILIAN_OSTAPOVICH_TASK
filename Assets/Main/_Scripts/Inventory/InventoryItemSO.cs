using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItemSO : ScriptableObject
{
    [Header("Inventory item properties")]
    public string Name => name;
    public Sprite sprite;
    public GameObject prefab;
    public int maxStackSize;
    [TextArea] public string description;
}
