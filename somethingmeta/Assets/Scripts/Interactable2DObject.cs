using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable2DObject : MonoBehaviour
{
    //Controller for input
    Player2DController player = null;
    [SerializeField] private UnityEvent OnKeyPress;

    //Generic response to PLAYER to being interacted with--this gets called elsewhere
    [SerializeField] private UnityEvent genericInteract;

    //Actions for correct/incorrect items
    [SerializeField] private UnityEvent correctItemHeld;
    [SerializeField] private UnityEvent incorrectItemHeld;

    //How close the player has to be to the object to interact with it
    [SerializeField] private float interactionRange = 2.0f;

    //Reference to the inventory manager for item check handling
    //TODO: It may be better to get the manager at startup rather than being passed in
    [SerializeField] private InventoryManager inventoryManager = null;

    //Does the response from this object change based on what the player is holding
    [SerializeField] private bool hasItemInteract = false;

    //Name of the correct item for interaction
    //Default is so that if there's no item interact the interactResponse method doesnt break
    [SerializeField] private string correctItemName = "default";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player2DController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Interact key is E, can change this later if needed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Checks if the player is within range
            float distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance <= interactionRange)
            {
                OnKeyPress.Invoke();
            }
        }
    }

    //Generic interaction response
    public void InteractResponse()
    {
        genericInteract.Invoke();

        //If there's no item interaction or the player isn't holding an item
        if (!hasItemInteract || inventoryManager.SelectedItem < 0)
        {
            genericInteract.Invoke();
        }
        else
        {
            checkForCorrectItem(correctItemName);
        }
    }

    //Calls events based on if the item is correct or not (determined by InventoryManager)
    public void CorrectItem()
    {
        correctItemHeld.Invoke();
    }

    public void IncorrectItem()
    {
        incorrectItemHeld.Invoke();
    }


    //Checks if there's a held item in the inventory, invokes the corresponding 
    public void checkForCorrectItem(string correctItemName)
    {
        InventoryObject currentObject = inventoryManager.InventoryArray[inventoryManager.SelectedItem].GetComponent<InventoryObject>();

        //Check the specified item vs the currently equipped one
        if (currentObject.ItemName.ToLower().Equals(correctItemName.ToLower()))
        {
            //Calls the method that invokes commands tied to if the item is correct
            CorrectItem();
        }
        else
        {
            IncorrectItem();
        }
    }
}
