using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] UIDialoguePanel dialoguePanel;
    [SerializeField] UIHotbar hotbar;

    private void Awake()
    {
        if (UIManager.instance) Destroy(this);
        else UIManager.instance = this;

        DontDestroyOnLoad(gameObject);

        SwitchToHotbarMode();
    }

    public void SwitchToDialogueMode(string npcName, Dialogue dialogue)
    {
        hotbar.gameObject.SetActive(false);
        dialoguePanel.gameObject.SetActive(true);
        dialoguePanel.SetDialogue(npcName, dialogue);
    }

    public void SwitchToHotbarMode()
    {
        dialoguePanel.gameObject.SetActive(false);
        hotbar.gameObject.SetActive(true);
    }
}
