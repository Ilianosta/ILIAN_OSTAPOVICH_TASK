using UnityEngine;

public class UIItemHold : MonoBehaviour
{
    [SerializeField] UIItem heldItem;
    public UIItem previousItem;
    public void SetHeldItem(UIItem item)
    {
        heldItem.SetItem(item.Item);
        previousItem = item;
    }

}
