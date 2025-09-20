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

    private void Start()
    {
        //Find the playercontroller component via the tag on player
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    //Enables the computer UI
    public void ComputerOn()
    {
        //Disable player movement
        player.canMove = false;

        //Turns on screen
        //I'd like to have this tied to the actual screen pos if possible, resolution concerns right now though
        computerScreen.SetActive(true);
    }

    //Disables computer UI
    public void ComputerOff()
    {
        //Enable player movement
        player.canMove = true;

        //Turns off screen
        computerScreen.SetActive(false);
    }

    //Loads the scene corresponding to the code entered
    public void Load2DScene()
    {
        //Makes sure the component was gotten
        if (codeInput != null)
        {
            Debug.Log(codeInput.text);
            //Valid Codes
            switch (codeInput.text)
            {
                //Loads the corresponding scene
                case "TEST1":
                    SceneManager.LoadScene("2DScene1");
                    break;
                case "TEST2":
                    SceneManager.LoadScene("2DScene2");
                    break;
                default:
                    Debug.Log("Invalid code entered");
                    break;
            }
        }
        else
        {
            Debug.Log("No input field found");
        }
    }

}
