using UnityEngine;

public class UIChest : MonoBehaviour
{
    [SerializeField] GameObject uiItemPrefab;
    [SerializeField] Transform uiItemParent;

    public void OpenChest(Chest chest)
    {
        foreach (Transform child in uiItemParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < chest.capacity; i++)
        {
            GameObject uiItemObj = Instantiate(uiItemPrefab, uiItemParent);
        }
    }
}
