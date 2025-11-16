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

    //Sets up the dictionary with all the scene names and the codes that correspond to them
    Dictionary<string, string> sceneCodes = new Dictionary<string, string>()
    {
        {"TEST1", "2DScene1"},
        {"TY4P", "Credits"},
        {"SB7YVT8", "BeastHunter"},
        {"S3HUN9E", "PicnicScene"},
        {"LAB", "Labyrinth"},
        {"ST5L313", "AltarPuzzle"}
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

        //Turns off screen
        computerScreen.SetActive(false);
    }

    //Loads the scene corresponding to the code entered
    public void Load2DScene()
    {
        //No more case sensitivity!
        codeInput.text = codeInput.text.ToUpper();
        
        //Makes sure the component was gotten
        if (codeInput != null)
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

    ////Runs the full fade and load transition so the coroutines aren't overlapping and you can actually see the thing fade
    //public IEnumerator SceneTransition(string sceneName)
    //{
    //    //Fade out
    //    yield return StartCoroutine(fadeTransition.FadeOut());

    //    //Loads scene
    //    yield return StartCoroutine(LoadSceneAsync(sceneName));

    //    //Fade in is handled separately since the object this script is attached to gets disabled
    //}

    ////Coroutine loads scene in background
    ////Means Load2DScene can wait for the load to finish before swapping scenes
    //private IEnumerator LoadSceneAsync(string sceneName)
    //{
    //    AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

    //    //Loop until the scene is loaded
    //    while (!asyncLoadScene.isDone)
    //    {
    //        yield return null;
    //    }

    //    //Hiding every object in the current scene
    //    foreach (GameObject gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
    //    {
    //        if (gameObject.name != "NotesUI" && gameObject.name != "FadeTransition")
    //        {
    //            gameObject.SetActive(false);
    //        }
    //    }

    //    //Swap to the new scene
    //    //Have to search for the scene by name since setActiveScene needs a Scene object
    //    SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    //}

}
