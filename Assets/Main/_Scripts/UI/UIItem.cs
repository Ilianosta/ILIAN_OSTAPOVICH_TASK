using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] TMP_Text itemNameTxt;
    [SerializeField] TMP_Text itemQuantityTxt;
    [SerializeField] Image itemIconImg;

    InventoryItem item;
    public void SetItem(InventoryItem item)
    {
        this.item = item;
        if (item == null)
        {
            itemNameTxt.text = "Empty";
            itemQuantityTxt.text = "";
            itemIconImg.sprite = null;
        }
        else
        {
            itemNameTxt.text = item._name;
            itemQuantityTxt.text = item.actualAmount.ToString();
            itemIconImg.sprite = item.sprite;
        }
    }

    public void HoldItem()
    {
        UIManager.instance.holdingItem.SetItem(item);
    }

    public void ChangeItemPosition(UIItem targetItem)
    {
        InventoryItem tempItem = targetItem.item;
        targetItem.SetItem(item);
        SetItem(tempItem);
    }
}
