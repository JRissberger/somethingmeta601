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
    private int moveSpeed = 4;
    public GameObject orientation;
    public GameObject parentObjectToTurn;

    //Light that's enabled/disabled while inspecting
    [SerializeField] private GameObject inspectLight;

    //Used for positioning the held object
    [SerializeField] GameObject camera;

    //Parenting the held object to the camera, giving access to it
    public GameObject Camera { get { return camera; } }
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

        }

        //NOTE: trying a fix for popup, manually applying gravity
        Vector3 yMove = new Vector3(0, -9.81f, 0);
        controller.Move(yMove * Time.deltaTime);

        //Current mouse position
        mousePosition = Input.mousePosition;

    }

    //Toggles the light that's enabled while inspecting an object
    //This gets called by the inspect system script, defined here so each object doesn't have to reference the light
    public void ToggleInspectLight()
    {
        inspectLight.SetActive(!inspectLight.activeSelf);
    }
}
