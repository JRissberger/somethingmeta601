using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //Declaring variables
    PlayerController player = null;
    Vector3 mousePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //Find the playercontroller component via the tag on player
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Accessing mouse position
        mousePos = player.mousePosition;

        //TODO: How to access click input? observer?
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"mouse position from other object: {mousePos}");
        }

    }
}
