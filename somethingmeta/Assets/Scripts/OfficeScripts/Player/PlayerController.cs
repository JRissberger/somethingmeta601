using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //Declaring variables
    private CharacterController controller;
    private int moveSpeed = 5;
    public GameObject orientation;
    public GameObject parentObjectToTurn;

    //Used for positioning the held object
    [SerializeField] GameObject camera;

    //Used for notes
    [SerializeField] private UnityEvent notes;

    //Get/Set values
    public Vector3 mousePosition { get; private set; } = Vector3.zero;

    //TODO: train of thought here is to edit this from other scripts as needed
    public bool canMove { get; set; } = true;

    //Use this to prevent the player from starting multiple interactions at once 
    //ie activating computer while inspecting an object
    public bool canInteract { get; set; } = true;

    //The current object held by the player
    //Updated by EquippableObject
    private EquippableObject heldObject = null;
    public EquippableObject HeldObject
    {
        get { return heldObject; }
        set { heldObject = value; }
    }

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

            //If there's a held object, update its position relative to the player
            //relative to camera??
            if (heldObject)
            {
                //Holding the object to bottom right of camera view
                heldObject.UpdatePosition(camera.transform.position + camera.transform.forward * 1f
                + camera.transform.right * 0.5f - camera.transform.up * 0.25f); 
            }

        }

        //Current mouse position
        mousePosition = Input.mousePosition;

    }
}
