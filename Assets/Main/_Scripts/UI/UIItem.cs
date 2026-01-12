using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] TMP_Text itemNameTxt;
    [SerializeField] TMP_Text itemQuantityTxt;
    [SerializeField] Image itemIconImg;
    InventoryItem item;
    public InventoryItem Item => item;
    public void SetItem(InventoryItem item)
    {
        this.item = item;
        if (item == null)
        {
            itemNameTxt.text = "";
            itemQuantityTxt.text = "";
            itemIconImg.color = new Color(0, 0, 0, 0);
        }
        else
        {
            itemNameTxt.text = item._name;
            itemQuantityTxt.text = item.actualAmount.ToString();
            itemIconImg.sprite = item.sprite;
            itemIconImg.color = Color.white;
        }
    }

    void Awake()
    {
        SetItem(null);
    }

    public void ChangeItemPosition(UIItem targetItem)
    {
        if(targetItem == null) return;
        
        InventoryItem tempItem = targetItem.Item;
        targetItem.SetItem(item);
        SetItem(tempItem);
    }

    public void OnHover()
    {
        if (item != null)
        {
            UIManager.instance.ShowHoverInfo($"{item._name} Quantity: {item.actualAmount} \n {item.description}");
        }
    }
}
