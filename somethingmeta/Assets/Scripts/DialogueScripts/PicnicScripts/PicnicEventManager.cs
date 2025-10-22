using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PicnicEventManager : MonoBehaviour
{
    public string bunnyNode;
    public string penguinNode;
    public string catNode;
    public string foxNode;
    public DialogueRunner DialogueRunner;
    private bool isDialogueRunning = false;

    public void BunnyDialogue()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(bunnyNode);
            isDialogueRunning = true;
        }
    }

    public void FoxDialogue()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(foxNode);
            isDialogueRunning = true;
        }
        
    }

    public void PenguinDialogue()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(penguinNode);
            isDialogueRunning = true;
        }
        
    }

    public void CatDialogue()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(catNode);
            isDialogueRunning = true;
        }
        
    }

    public void ResetDialogueBool()
    {
        isDialogueRunning = false;
    }
}
