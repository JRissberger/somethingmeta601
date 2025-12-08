using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Computer : MonoBehaviour
{
    //Reference to the UI canvas
    [SerializeField] private GameObject computerScreen;

    //Reference to the text input
    [SerializeField] private TMP_InputField codeInput;

    //Gets a reference to the player for movement control
    PlayerController player = null;

    //Reference to the fade transition
    FadeTransition fadeTransition = null;

    //Scene transition manager
    [SerializeField] TransitionManager transitionManager;

    //Audio that plays when turning off the computer
    [SerializeField] AudioSource computerOffAudio;

    //Turn on computer
    [SerializeField] AudioSource computerOnAudio;

    //Sets up the dictionary with all the scene names and the codes that correspond to them
    Dictionary<string, string> sceneCodes = new Dictionary<string, string>()
    {
        {"TEST1", "2DScene1"},
        {"TY4P", "Credits"},
        {"SB7YVT8", "BeastHunter"},
        {"S3HUN9E", "PicnicScene"},
        {"SC0NNIE", "Labyrinth"},
        {"ST5L313", "AltarPuzzle"},
        {"OUTRO", "OutroSection" }
    };

    private void Start()
    {
        //Find the playercontroller component via the tag on player
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        fadeTransition = GameObject.Find("FadeTransition").GetComponent<FadeTransition>();
    }

    //Enables the computer UI
    public void ComputerOn()
    {
        //Only turn on computer if the player isn't already interacting with something
        if (player.canInteract)
        {
            //Disable player movement
            player.canMove = false;
            player.canInteract = false;
            player.inComputerMenu = true;

            //Play audio
            if (computerOnAudio != null)
            {
                computerOnAudio.Play();
            }

            //Turns on screen
            //I'd like to have this tied to the actual screen pos if possible, resolution concerns right now though
            computerScreen.SetActive(true);
        }
    }

    //Disables computer UI
    public void ComputerOff()
    {
        //Enable player movement
        player.canMove = true;
        player.canInteract = true;
        player.inComputerMenu = false;

        //Plays audio
        if (computerOffAudio != null)
        {
            computerOffAudio.Play();
        }
        //Turns off screen
        computerScreen.SetActive(false);
    }

    //Loads the scene corresponding to the code entered
    public void Load2DScene()
    {
        //No more case sensitivity!
        codeInput.text = codeInput.text.ToUpper();
        
        //Makes sure the component was gotten
        if (codeInput != null && !transitionManager.inTransition)
        {
            //Tries to load the corresponding scene
            try
            {
                //StartCoroutine(SceneTransition(sceneCodes[codeInput.text]));
                //Calls transition manager
                transitionManager.SwitchScenes(sceneCodes[codeInput.text]);

            }
            //TODO: response to player for invalid code
            catch
            {
                Debug.Log("Invalid code");
            }
        }
        else
        {
            Debug.Log("No input field found");
        }
    }

}
