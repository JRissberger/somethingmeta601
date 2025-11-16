using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Get reference to inventory UI, player
    [SerializeField] private Canvas inventoryUI;
    private Player2DController player = null;
    
    //The index of the currently selected item
    //-1 indicates nothing's selected
    private int selectedItem = -1;

    //Inventory array
    private InventoryObject[] inventoryArray = new InventoryObject[4];

    //Buttons corresponding to the inventory slots
    [SerializeField] private Button[] inventoryButtons = new Button[4];

    //Access to array and current item
    public InventoryObject[] InventoryArray { get { return inventoryArray; } }
    public int SelectedItem { get { return selectedItem; } }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player2DController>();

        //Adds click listeners to the UI buttons
        for (int i = 0; i < inventoryButtons.Length; i++)
        {
            //Saves current index value
            int current = i;

            //Have to use an arrow function to pass in parameter
            inventoryButtons[i].onClick.AddListener(() => UpdateSelectedItem(current));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if in dialogue, toggle UI 
        //Should be a bool from player
        //TODO: currently this updates every frame, should change just on toggle
        //Is there an observer available?
        inventoryUI.gameObject.SetActive(true);
    }

    //Updates the currently selected item when a button is pressed
    public void UpdateSelectedItem(int index)
    {
        //Temporarily holds the previous object
        int previousSelected = selectedItem;

        //Resets color of previously selected slot if applicable
        if (previousSelected >= 0)
        {
            Image previousBackground = inventoryButtons[previousSelected].GetComponent<Image>();
            previousBackground.color = Color.white;
        }
        
        //Updates selected item IF a different one was picked
        //If it's the same one, just works as a deselect
        if (previousSelected != index)
        {
            //Saves the index of the currently selected item
            selectedItem = index;

            //Highlights the corresponding inventory slot
            Image background = inventoryButtons[index].GetComponent<Image>();
            background.color = Color.yellow;

            //If there's no sprite in the slot, hide the sprite child
            Image icon = inventoryButtons[index].transform.Find("Icon").GetComponent<Image>();
            icon.enabled = (icon.sprite != null);
        }
        else
        {
            //-1 is deselect value
            selectedItem = -1;
        }

    }

    //Add an object to the inventory
    //Gameobject required from the editor--it's a drag and drop
    public void AddToInventory(InventoryObject item)
    {
        //Find the first empty slot
        for (int i = 0; i < inventoryArray.Length; i++)
        {
            if (inventoryArray[i] == null)
            {
                inventoryArray[i] = item;

                //Get the sprite from the item
                SpriteRenderer itemSprite = item.GetComponent<SpriteRenderer>();

                //Attach it to the button
                //Icon is used so that there's still a background 
                if (item.Sprite != null)
                {
                    Image spriteHolder = inventoryButtons[i].transform.Find("Icon").GetComponent<Image>();
                    spriteHolder.sprite = item.Sprite.sprite;

                    //Enables sprite visibility
                    spriteHolder.enabled = true;
                }

                //Hides item so it can't be added multiple times
                item.gameObject.SetActive(false);

                break;
            }
        }
    }


    //Removes the item from inventory
    //Can opt to return it to the overworld or not
    void RemoveFromInventory(string itemName, bool returnToWorld)
    {
        //Loops through the array to find an item with the specified name
        for (int i = 0; i < inventoryArray.Length; i++)
        {
            //Check for a name match
            if (inventoryArray[i] != null)
            {
                if (inventoryArray[i].GetComponent<InventoryObject>().ItemName.ToLower().Equals(itemName.ToLower()))
                {
                    //Return to overworld if applicable
                    inventoryArray[i].gameObject.SetActive(returnToWorld);

                    //Remove sprite from button
                    Image spriteHolder = inventoryButtons[i].transform.Find("Icon").GetComponent<Image>();
                    spriteHolder.sprite = null;
                    spriteHolder.enabled = false;

                    //Remove from array
                    inventoryArray[i] = null;
                }
            }
        }
    }

    //"Overloads" for return to inventory (editor can only have 0-1 parameters)

    //Returns to the overworld
    public void ReturnItem(string itemName)
    {
        RemoveFromInventory(itemName, true);
    }

    //Removes the item without returning
    public void RemoveItem(string itemName)
    {
        RemoveFromInventory(itemName, false);
    }

}
