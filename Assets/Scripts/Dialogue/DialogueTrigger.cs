using UnityEngine;

/// <summary>
/// Class to put on GameObject and create custom dialogue, call TriggerDialogue() to start
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
