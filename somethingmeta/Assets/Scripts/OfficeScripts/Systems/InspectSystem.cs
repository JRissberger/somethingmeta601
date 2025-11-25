using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InspectSystem : MonoBehaviour
{
    //Object being viewed
    [SerializeField] private Transform objectToInspect;

    private float rotationSpeed = 100f;

    private Vector3 previousMousePosition;

    //Holds the original object location for reset
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private Quaternion inspectRotation;

    //Checks if inspection is happening
    private bool isInspecting = false;

    //Player reference (lock movement)
    private PlayerController player = null;

    //Inspection UI
    //Have to pass in via editor since it's hidden by default, can't search for it
    [SerializeField] private GameObject inspectUI;
    //How far in front of the player to place the object when inspecting
    [SerializeField] private float inspectDistance = 1.0f;

    //Does the object have hidden text?
    [SerializeField] private bool hasObscuredText = false;

    //Text elements for if there's hidden text to toggle
    [SerializeField] private TMP_Text obscuredText;
    [SerializeField] private TMP_Text legibleText;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        //Saves the original object position and rotation
        originalPosition = objectToInspect.position;
        originalRotation = objectToInspect.rotation;

        inspectRotation = Quaternion.identity;

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

            isInspecting = true;
            player.canMove = false;
            player.canInteract = false;

            //Enables the light used for inspection
            player.ToggleInspectLight();

            //Centers the object in front of the player
            objectToInspect.position = player.transform.position + player.transform.forward * inspectDistance;

            //Display inspect UI
            inspectUI.SetActive(true);

            StartCoroutine(ResetRotation());

            //Switches to revealed text if applicable
            if (hasObscuredText)
            {
                Debug.Log("Showing Text");
                RevealText();
            }
        }
    }

    //In which I brute force a rotation reset
    //Because for some reason the first time it gets set, the update order is odd enough that it doesn't display
    private IEnumerator ResetRotation()
    {
        yield return null;
        objectToInspect.rotation = Quaternion.identity;
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

        //Disables the light used for inspection
        player.ToggleInspectLight();

        //Switches to obscured text if applicable
        if (hasObscuredText)
        {
            HideText();
        }
    }

    //Toggles for hidden text if applicable
    private void RevealText()
    {
        //Only run if there's been text elements assigned
        if (obscuredText && legibleText)
        {
            obscuredText.gameObject.SetActive(false);
            legibleText.gameObject.SetActive(true);
        }
    }

    private void HideText()
    {
        //Only run if there's been text elements assigned
        if (obscuredText && legibleText)
        {
            obscuredText.gameObject.SetActive(true);
            legibleText.gameObject.SetActive(false);
        }
    }
}
