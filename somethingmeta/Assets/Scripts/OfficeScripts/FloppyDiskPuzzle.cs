using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyDiskPuzzle : MonoBehaviour
{
    [SerializeField] GameObject[] floppyDiskPieces;
    private bool[] floppyDiskPlaced = { false, false, false };
    [SerializeField] GameObject[] floppyDiskPlacement;
    [SerializeField] GameObject completeFloppyDisk;

    //References player to update equipped object
    private PlayerController player = null;

    /// <summary>
    /// Sets the player to the player controller.
    /// </summary>
    public void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    /// <summary>
    /// Finds the player gameObject, checks it with all "correct" floppy disk pieces. If it is incorrect, nothing happens. If it is true, set the bool and remove the gameObject.
    /// </summary>
    public void CheckFloppyPiece()
    {
        if (floppyDiskPieces.Length > 0 && player != null)
        {
            EquippableObject heldItem = player.HeldObject;
            for (int i = 0; i < floppyDiskPieces.Length; i++)
            {
                GameObject heldGameObject = heldItem.gameObject;
                Debug.Log(heldGameObject);
                if (floppyDiskPieces[i].name == heldItem.gameObject.name)
                {
                    Debug.Log(floppyDiskPieces[i] + " " + heldItem);
                    floppyDiskPlaced[i] = true;
                    heldItem.DropObject();
                    PlaceFloppyPiece(i);
                    IsFloppyComplete();
                    Destroy(heldItem.gameObject);
                    
                    // CHECK ALL 3 ARE DELETED
                    break;
                }
            }
        }

    }

    private void PlaceFloppyPiece(int piece)
    {
        floppyDiskPlacement[piece].SetActive(true);
    }

    private void IsFloppyComplete()
    {
        bool isComplete = true;
        for (int i = 0;i < floppyDiskPieces.Length; i++)
        {
            if (floppyDiskPlaced[i] == false)
            {
                isComplete = false;
            }
        }

        if (isComplete)
        {
            for (int i = 0; floppyDiskPlacement.Length > i; i++)
            {
                floppyDiskPlacement[i].SetActive(false);
            }
            completeFloppyDisk.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    
}
