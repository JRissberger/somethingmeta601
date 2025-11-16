using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerStartFloppyInsert : MonoBehaviour
{
    [SerializeField] Animator floppyReader;
    [SerializeField] InteractableObject computerInteractable;

    public void InsertFloppy()
    {
        floppyReader.SetBool("HasFloppy", true);
        computerInteractable.enabled = true;
    }
    
}
