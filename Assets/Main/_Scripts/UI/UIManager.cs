using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] UIDialoguePanel dialoguePanel;
    [SerializeField] UIHotbar hotbarPanel;
    [SerializeField] UIChest chestPanel;
    private void Awake()
    {
        if (UIManager.instance) Destroy(this);
        else UIManager.instance = this;

        DontDestroyOnLoad(gameObject);

        SwitchToHotbarMode();
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

    public void OpenChestUI(Chest chest)
    {
        CloseAll();
        chestPanel.gameObject.SetActive(true);
        chestPanel.OpenChest(chest);
    }

    void CloseAll()
    {
        dialoguePanel.gameObject.SetActive(false);
        hotbarPanel.gameObject.SetActive(false);
        chestPanel.gameObject.SetActive(false);
    }
}
