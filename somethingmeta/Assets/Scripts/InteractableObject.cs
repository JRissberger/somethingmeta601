using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements.Experimental;
public class InteractableObject : MonoBehaviour
{
    //Declaring variables
    PlayerController player = null;
    private TextMeshProUGUI interactionTextUI;
    Vector3 mousePos = Vector3.zero;
    [SerializeField] private string interactText = "UNKNOWN INTERACTION TEXT";
    private bool endLook = false;
    [SerializeField] private UnityEvent EventsWhenClicked;
    private Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        //Creating and determining what the outline looks like.
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
        outline.enabled = false;

        
        //Find the playercontroller component via the tag on player
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        interactionTextUI = GameObject.FindWithTag("InteractText").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //turns off the outline every frame.
        outline.enabled = false;
        
        //Accessing mouse position
        mousePos = player.mousePosition;

        //Trying to use raycasting
        //Have to convert 2d mouse position to 3d environment
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit rayHit;
        
        //Check if the ray hits the object collider
        //TODO: handle depth limits, don't want the player to be able to interact with something from far away
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, 5f))
        {
            Debug.DrawRay(ray.origin, ray.direction);

            //Debug.Log("Hovering over object");
            if (rayHit.collider.gameObject == this.gameObject)
            {
                //turns on the outline if the object is getting hit by the raycast. 
                outline.enabled = true;
                
                Debug.Log(this.gameObject.name);

                    //Detects if the mouse is clicked while over the object
                    if (Input.GetMouseButtonDown(0))
                    {
                        EventsWhenClicked.Invoke();
                    }

                
            }
        }
        if (outline.enabled)
        {
            Debug.Log("If this does not work imma kms");
            endLook = true;
            interactionTextUI.text = interactText;
        }
        else
        {
            if (endLook)
            {
                interactionTextUI.text = ""; 
            }
            endLook = false;
        }


    }

    //Debug
    public void ConsolePrintClickedObject()
    {
        Debug.Log("You have clicked the " + this.gameObject.name + "!");
    }
}
