using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectSystem : MonoBehaviour
{
    //Object being viewed
    [SerializeField] private Transform objectToInspect;

    private float rotationSpeed = 100f;

    private Vector3 previousMousePosition;

    //Holds the original object location for reset
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    //Checks if inspection is happening
    private bool isInspecting = false;

    //Player reference (lock movement)
    private PlayerController player = null;

    //Inspection UI
    //Have to pass in via editor since it's hidden by default, can't search for it
    [SerializeField] private GameObject inspectUI;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        //Saves the original object position and rotation
        originalPosition = objectToInspect.position;
        originalRotation = objectToInspect.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Only moves the object if there's an inspection happening
        if (isInspecting)
        {
            //Updates the last known mouse position on click
            if (Input.GetMouseButtonDown(0))
            {
                previousMousePosition = Input.mousePosition;
            }

            //Gets the difference in the two mouse positions if the button is being held
            if (Input.GetMouseButton(0))
            {

                Vector3 deltaMousePosition = Input.mousePosition - previousMousePosition;

                //Gets the rotation angle
                float rotationX = deltaMousePosition.y * rotationSpeed * Time.deltaTime;
                float rotationY = -deltaMousePosition.x * rotationSpeed * Time.deltaTime;

                //Applies rotation
                Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
                objectToInspect.rotation = rotation * objectToInspect.rotation;

                previousMousePosition = Input.mousePosition;
            }

            //End inspection
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("ending inspection");
                endInspection();
            }
        }
    }

    //Starts inspection, this gets called by interactable object
    public void startInspection()
    {
        //Technically this can get called mid inspection because of the event system
        if (!isInspecting && player.canInteract)
        {
            //Records the original position
            isInspecting = true;
            player.canMove = false;
            player.canInteract = false;

            //Centers the object in front of the camera
            objectToInspect.position = player.transform.position + player.transform.forward * 1f;

            //Display inspect UI
            inspectUI.SetActive(true);

        }
    }

    //Ends inspection (happens when player presses esc)
    public void endInspection()
    {
        //Resets the object position
        objectToInspect.position = originalPosition;
        objectToInspect.rotation = originalRotation;

        isInspecting = false;
        player.canMove = true;
        player.canInteract = true;
        inspectUI.SetActive(false);
    }
}
