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

    private void Update()
    {
        //For now, pressing E drops the item. can change later if needed
        if (Input.GetKeyDown(KeyCode.E))
        {
            DropObject();
        }
    }

    //Equips the object to the player
    //Player can only hold one item at a time
    public void EquipObject()
    {
        if (!player.HeldObject)
        {
            player.HeldObject = this;
        }
    }

    //Called by the player script to update the position of a held object 
    public void UpdatePosition(Vector3 position)
    {
        this.transform.position = position;
    }

    //Drops the currently object if held
    //TODO: may change to just drop the object in front of the player?
    public void DropObject()
    {
        if (player.HeldObject == this)
        {
            player.HeldObject = null;
            this.gameObject.transform.position = originalPosition;
        }

    }
}
