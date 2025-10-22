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

    public void BunnyDialogue()
    {
        DialogueRunner.StartDialogue(bunnyNode);
    }

    public void FoxDialogue()
    {
        DialogueRunner.StartDialogue(foxNode);
    }

    public void PenguinDialogue()
    {
        DialogueRunner.StartDialogue(penguinNode);
    }

    public void CatDialogue()
    {
        DialogueRunner.StartDialogue(catNode);
    }
}
