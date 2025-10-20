using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class InventoryObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite = null;
    [SerializeField] private string itemName = "default";

    //Allow access to name
    public string ItemName { get; }

}
