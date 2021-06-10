using Doozy.Engine;
using Doozy.Engine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    public TextMeshProUGUI NameText, DialogueText;

    private UIView dialogueView;
    private Queue<string> sentences = new Queue<string>();

    protected void Start()
    {
        dialogueView = UIView.GetViews("General", "Dialogue")[0];
    }

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

    public void EndDialogue()
    {
        dialogueView.Hide();
        GameEventMessage.SendEvent("EndDialogue");

        Debug.Log("Dialogue has ended.");
    }
}
