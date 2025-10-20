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
    private int selectedItem = 0;

    //Inventory array
    private GameObject[] inventoryArray = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player2DController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if in dialogue, toggle UI 
        //Should be a bool from player
        //TODO: currently this updates every frame, should change just on toggle
        //Is there an observer available?
        if (player.inDialogue)
        {
            inventoryUI.gameObject.SetActive(false);
        }
        else
        {
            inventoryUI.gameObject.SetActive(true);
        }
    }

    //Updates the currently selected item when a button is pressed
    public void UpdateSelectedItem(int index)
    {
        //Button has an index passed from the UI

        //Make button visually distinct
    }

    //Add an object to the inventory
    //Gameobject required from the editor--it's a drag and drop
    //TODO: needs testing
    public void AddToInventory(GameObject item)
    {
        //Find the first empty slot
        for (int i = 0; i < inventoryArray.Length; i++)
        {
            if (inventoryArray[i] == null)
            {
                inventoryArray[i] = item;

                //TODO: update button icon here
                break;
            }
        }
    }


    //Checking correct item
    //Pass in required name, check if current selected item name matches
    //follow flowchart accordingly

}
