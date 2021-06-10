using Doozy.Engine;
using Doozy.Engine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Handles dialogue, show/hide, update text to screen and handle dialogue tree
/// </summary>
public class DialogueManager : Singleton<DialogueManager>
{
    public TextMeshProUGUI NameText, DialogueText;

    private UIView dialogueView;
    private Queue<string> sentences = new Queue<string>();

    protected void Start()
    {
        dialogueView = UIView.GetViews("General", "Dialogue")[0];
    }

    /// <summary>
    /// Start dialogue, show dialogue box and update text with name and first sentence
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.LogFormat("{0} has started dialogue.", dialogue.name);

        sentences.Clear();
        foreach(var sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        if (NameText != null)
            NameText.text = dialogue.name;

        NextSentence();

        dialogueView.Show();
        GameEventMessage.SendEvent("StartDialogue");
    }

    /// <summary>
    /// Go to next setence in dialogue
    /// </summary>
    public void NextSentence()
    {
        if (sentences.Count == 0) EndDialogue();
        else
        {
            string sentence = sentences.Dequeue();
            if (DialogueText != null)
                DialogueText.text = sentence;
        }
    }

    /// <summary>
    /// End dialogue, no more sentences left
    /// </summary>
    public void EndDialogue()
    {
        dialogueView.Hide();
        GameEventMessage.SendEvent("EndDialogue");

        Debug.Log("Dialogue has ended.");
    }
}
