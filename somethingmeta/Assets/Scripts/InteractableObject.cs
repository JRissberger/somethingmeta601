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

        //Detects if the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"mouse position from other object: {mousePos}");
        }

        //Trying to use raycasting
        //Have to convert 2d mouse position to 3d environment
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit rayHit;

        //Check if the ray hits the object collider
        //TODO: handle depth limits, don't want the player to be able to interact with something from far away
        if (Physics.Raycast(ray, out rayHit))
        {
            Debug.Log("Hovering over object");
        }

    }
}
