using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AL_PondScript : MonoBehaviour
{

    [SerializeField] private DialogueRunner dialogue;

    // Start is called before the first frame update
    public void StartDialogue(string name)
    {
        dialogue.StartDialogue(name);
    }
}
