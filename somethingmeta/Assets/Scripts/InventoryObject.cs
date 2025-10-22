using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.Events;

public class InventoryObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private string itemName = "default";

    //Actions for correct items
    [SerializeField] private UnityEvent correctSelection;
    [SerializeField] private UnityEvent incorrectSelection;

    //Allow access to name
    public string ItemName { get { return itemName; } }

    public SpriteRenderer Sprite { get { return sprite; } }


    //Calls events based on if the item is correct or not (determined by InventoryManager)
    public void CorrectItem()
    {
        correctSelection.Invoke();
    }

    public void IncorrectItem()
    {
        incorrectSelection.Invoke();
    }
}
