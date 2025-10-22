using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable2DObject : MonoBehaviour
{
    //Controller for input
    Player2DController player = null;
    [SerializeField] private UnityEvent OnKeyPress;

    //Generic response to PLAYER to being interacted with--this gets called elsewhere
    [SerializeField] private UnityEvent genericInteract;

    //How close the player has to be to the object to interact with it
    [SerializeField] private float interactionRange = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player2DController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Interact key is E, can change this later if needed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Checks if the player is within range
            float distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance <= interactionRange)
            {
                OnKeyPress.Invoke();
            }
        }
    }

    //Generic interaction response
    public void GenericResponse()
    {
        genericInteract.Invoke();
    }
}
