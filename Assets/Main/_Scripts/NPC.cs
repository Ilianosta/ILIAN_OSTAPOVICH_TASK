using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] string _name;
    [SerializeField] Dialogue dialogue;
    [SerializeField] Outline outline;
    public void Interact()
    {
        Talk();
    }

    public void Outline(bool enable)
    {
        outline.enabled = enable;
    }

    public void Talk()
    {
        UIManager.instance.SwitchToDialogueMode(_name, dialogue);
    }
}

[System.Serializable]
public class Dialogue
{
    public string[] lines;

    public Dialogue(string[] lines)
    {
        this.lines = lines;
    }
}
