using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] UIDialoguePanel dialoguePanel;
    [SerializeField] UIHotbar hotbarPanel;
    [SerializeField] UIChest chestPanel;
    [SerializeField] TMP_Text hoverInfoTxt;
    public UIItemHold itemHold;
    public GameObject hoverInfo;

    public bool isHoldingItem;

    private void Awake()
    {
        if (UIManager.instance) Destroy(this);
        else UIManager.instance = this;

        DontDestroyOnLoad(gameObject);

        SwitchToHotbarMode();
    }

    void Start()
    {
        SetCursorState(false);
    }

    public void SetCursorState(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void SwitchToDialogueMode(string npcName, Dialogue dialogue)
    {
        CloseAll();
        dialoguePanel.gameObject.SetActive(true);
        dialoguePanel.SetDialogue(npcName, dialogue);
    }

    public void SwitchToHotbarMode()
    {
        CloseAll();
        hotbarPanel.gameObject.SetActive(true);
    }

    public void OpenChestUI(Inventory<InventoryItem> inventory)
    {
        CloseAll();
        chestPanel.gameObject.SetActive(true);
        chestPanel.OpenChest(inventory);
    }

    void CloseAll()
    {
        dialoguePanel.gameObject.SetActive(false);
        hotbarPanel.gameObject.SetActive(false);
        chestPanel.gameObject.SetActive(false);
    }

    public void ShowHoverInfo(string info)
    {
        if (isHoldingItem) return;

        hoverInfoTxt.text = info;
        hoverInfo.SetActive(true);
    }
}
