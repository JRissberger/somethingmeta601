using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //Declaring variables
    private CharacterController controller;
    private int moveSpeed = 5;
    public GameObject orientation;
    public GameObject parentObjectToTurn;

    //Used for notes
    [SerializeField] private UnityEvent notes;

    //Get/Set values
    public Vector3 mousePosition { get; private set; } = Vector3.zero;

    //TODO: train of thought here is to edit this from other scripts as needed
    public bool canMove { get; set; } = true;

    //Use this to prevent the player from starting multiple interactions at once 
    //ie activating computer while inspecting an object
    public bool canInteract { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the controller component
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //Movement controls, user must not be in a menu/inspecting an object
        if (canMove)
        {
            //Gets X and Z axis inputs
            //Horizontal/Vertical refer to AD/WS, which is why the Z axis is vertical
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            //Calculates vector movement
            Vector3 movement = transform.right * x + transform.forward * z;

            //Applies movement to controller
            controller.Move(movement * moveSpeed * Time.deltaTime);
            parentObjectToTurn.transform.rotation = orientation.transform.rotation;

        }

        //Current mouse position
        mousePosition = Input.mousePosition;

    }
}
