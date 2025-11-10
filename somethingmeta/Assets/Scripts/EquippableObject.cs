using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableObject : MonoBehaviour
{
    //References player to update equipped object
    private PlayerController player = null;

    //Stores the original position before the player can move the object
    //May be used for drop object for the time being
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        originalPosition = this.gameObject.transform.position;
    }

    //Equips the object to the player
    public void EquipObject()
    {
        player.HeldObject = this;
    }

    //Called by the player script to update the position of a held object 
    public void UpdatePosition(Vector3 position)
    {
        this.transform.position = position;
    }

    //Drops the currently held object
    //TODO: key press? where will it go? onto the floor in front of the player? back to the og position?
    public void DropObject()
    {
        player.HeldObject = null;
        this.gameObject.transform.position = originalPosition;
    }
}
