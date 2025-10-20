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
    private GameObject[] inventoryArray = new GameObject[4];

    //Buttons corresponding to the inventory slots
    [SerializeField] private Button[] inventoryButtons = new Button[4];

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
        inventoryUI.gameObject.SetActive(!player.inDialogue);
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
    public void AddToInventory(GameObject item)
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
                if (itemSprite != null)
                {
                    Image spriteHolder = inventoryButtons[i].transform.Find("Icon").GetComponent<Image>();
                    spriteHolder.sprite = itemSprite.sprite;

                    //Enables sprite visibility
                    spriteHolder.enabled = true;
                }

                //Hides item so it can't be added multiple times
                item.SetActive(false);

                break;
            }
        }
    }


    //Checking correct item
    //Pass in required name, check if current selected item name matches
    //follow flowchart accordingly

}
