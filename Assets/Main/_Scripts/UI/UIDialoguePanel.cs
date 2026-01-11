using TMPro;
using UnityEngine;

public class UIDialoguePanel : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueTxt, nameTxt;
    Dialogue currentDialogue;
    int currentLineIndex = 0;
    void OnEnable()
    {
        InputManager.Instance.inputActions.Dialogue.Enable();
        InputManager.Instance.inputActions.Game.Disable();
        InputManager.Instance.inputActions.Dialogue.Skip.performed += ctx => ShowNextLine();
    }

    void OnDisable()
    {
        InputManager.Instance.inputActions.Dialogue.Disable();
        InputManager.Instance.inputActions.Game.Enable();
        InputManager.Instance.inputActions.Dialogue.Skip.performed -= ctx => ShowNextLine();
    }

    public void SetDialogue(string name, Dialogue dialogue)
    {
        nameTxt.text = name;
        currentDialogue = dialogue;
        dialogueTxt.text = dialogue.lines[currentLineIndex];
    }

    void ShowNextLine()
    {
        if (currentDialogue == null) return;
        currentLineIndex++;
        if (currentLineIndex < currentDialogue.lines.Length)
        {
            dialogueTxt.text = currentDialogue.lines[currentLineIndex];
        }
        else
        {
            ClearDialogue();
            currentLineIndex = 0;
            currentDialogue = null;
            UIManager.instance.SwitchToHotbarMode();
        }
    }

    public void ClearDialogue()
    {
        nameTxt.text = "";
        dialogueTxt.text = "";
    }
}
