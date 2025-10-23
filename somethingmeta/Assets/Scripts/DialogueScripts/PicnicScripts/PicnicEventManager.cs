using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PicnicEventManager : MonoBehaviour
{
    [Header("Bunny Dialogue")]
    public string bunnyGenericNode;

    public string bunnyCorrectNode;
    public string bunnyIncorrectNode;
    private bool bunnyHappy = false;

    [Header("Penguin Dialogue")]
    public string penguinGenericNode;

    public string penguinCorrectNode;
    public string penguinIncorrectNode;
    private bool penguinHappy = false;
    [Header("Cat Dialogue")]
    public string catGenericNode;

    public string catCorrectNode;
    public string catIncorrectNode;
    private bool catHappy = false;
    [Header("Fox Dialogue")]
    public string foxGenericNode;
    public string foxCorrectNode;
    public string foxIncorrectNode;
    private bool foxHappy = false;


    public DialogueRunner DialogueRunner;
    private bool isDialogueRunning = false;

    public void BunnyDialogue()
    {
        if (isDialogueRunning == false)
        {
            if (bunnyHappy)
            {
                DialogueRunner.StartDialogue(bunnyCorrectNode);
            }
            else
            {
                DialogueRunner.StartDialogue(bunnyGenericNode);
            }
                isDialogueRunning = true;
        }
    }

    public void BunnyUnhappy()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(bunnyIncorrectNode);
            isDialogueRunning = true;
        }
    }

    public void BunnyGivenItem()
    {
        bunnyHappy = true;
    }
  

    public void FoxDialogue()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(foxGenericNode);
            isDialogueRunning = true;
        }
        
    }

    public void FoxUnhappy()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(foxIncorrectNode);
            isDialogueRunning = true;
        }
    }

    public void FoxGivenItem()
    {
        foxHappy = true;
    }

    public void PenguinDialogue()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(penguinGenericNode);
            isDialogueRunning = true;
        }
        
    }

    public void PenguinUnhappy()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(penguinIncorrectNode);
            isDialogueRunning = true;
        }
    }

    public void PenguinGivenItem()
    {
        penguinHappy = true;
    }

    public void CatDialogue()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(catGenericNode);
            isDialogueRunning = true;
        }
        
    }
    public void CatUnhappy()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(catIncorrectNode);
            isDialogueRunning = true;
        }
    }

    public void CatGivenItem()
    {
        catHappy = true;
    }

    public void ResetDialogueBool()
    {
        isDialogueRunning = false;
    }
}
