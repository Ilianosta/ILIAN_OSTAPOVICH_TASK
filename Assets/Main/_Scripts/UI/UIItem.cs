using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] TMP_Text itemNameTxt;
    [SerializeField] TMP_Text itemQuantityTxt;
    [SerializeField] Image itemIconImg;

    public void SetItem(InventoryItem item)
    {
        if (item == null)
        {
            itemNameTxt.text = "Empty";
            itemQuantityTxt.text = "";
            itemIconImg.sprite = null;
            itemIconImg.color = new Color(1, 1, 1, 0); // Make icon invisible
        }
        else
        {
            itemNameTxt.text = item._name;
            itemQuantityTxt.text = item.actualAmount.ToString();
            itemIconImg.sprite = item.sprite;
            itemIconImg.color = new Color(1, 1, 1, 1); // Make icon visible
        }
    }
}
