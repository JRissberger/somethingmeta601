using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declaring variables
    private CharacterController controller;
    private int moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the controller component
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets X and Z axis inputs
        //Horizontal/Vertical refer to AD/WS, which is why the Z axis is vertical
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Calculates vector movement
        Vector3 movement = transform.right * x + transform.forward * z;

        //Applies movement to controller
        controller.Move(movement * moveSpeed * Time.deltaTime);

        //TODO: Camera movement

        //Current mouse position
        Vector3 mousePosition = Input.mousePosition;

        /*TODO: Handling clickable objects
         * Either mousePosition needs to get passed to other classes
         * Or check objects here
         * Probably pass to an interactable class */
        
        //Response when the player left clicks
        //TODO: Handling depth
        //Z axis is always 0, the current location of the player. 
        //Simple solution is probably just to flat add onto that
        //Interactible can highlight if the z distance is lower?
        if (Input.GetMouseButtonDown(0))
        {
            //XYZ order
            Debug.Log($"Mouse position: {mousePosition}");
        }

    }
}
