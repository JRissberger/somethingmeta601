using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemVisualTesting : MonoBehaviour
{
    [SerializeField] private InventoryManager player;
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.SelectedItem != -1 && player.InventoryArray[player.SelectedItem].GetComponent<InventoryObject>() != null)
            {
                text.text = "Held Item: " + player.InventoryArray[player.SelectedItem].GetComponent<InventoryObject>().ItemName;
                
            }
            else
            {
                text.text = "Held Item: ";
            }
        }
    }
}
