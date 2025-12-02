using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LabyrinthManager : MonoBehaviour
{
    //All the triggers for crossing a threshold. 
    //TODO: may change this to get the gameobject and look at its children
    //Will depend on how assets are set up
    [SerializeField] private List<BoxCollider2D> triggers;

    private bool isRunning = false;

    //Canvas with the crash info
    [SerializeField] private GameObject crashScreen;

    //Temporary horror screen
    [SerializeField] private GameObject horrorScreen;
    //Used for the transition back to office
    [SerializeField] private ForceShutoff transition;

    //Counter for how many times the player has crossed a threshold
    //Crashes the game if it's at 7
    private float counter = 0;

    //Used since the crash routine takes multiple frames, keeps it from being called multiple times
    //Since the check for crash is in update which runs every frame
    private bool isCrashing = false;

    //runs dialogue for the dev note
    [SerializeField] DialogueRunner dialogueRunner;

    //Loops to check for any triggers

    //Increments the counter
    //Increments by 0.5 since technically each half of a corridor has a threshold
    //So each threshold pings twice
    public void increaseCounter()
    {
        counter += 0.5f;
        Debug.Log(counter);
    }

    //Resets the counter
    //Used when interacting with an object in the labyrinth
    public void resetCounter()
    {
        Debug.Log("Counter reset");
        counter = 0f;
    }

    //Switch to crash screen, then forcequit
    //Enable crash panel, wait X amount of seconds
    private void crashGame()
    {
        crashScreen.SetActive(true);
        Debug.Log("Game crash");
        StartCoroutine(waitTransition());
    }

    //Using a coroutine to wait a set time before switching back to office
    private IEnumerator waitTransition()
    {
        yield return new WaitForSeconds(3f);
        transition.forceShutoff();
    }

    //CURRENTLY PLACEHOLDER

    public void FinishLabyrinth()
    {
        horrorScreen.SetActive(true);
        Debug.Log("I FOUND YOU");
        StartCoroutine(waitTransition());
    }

    private void Update()
    {
        //Checks what the counter's at
        //TODO: bc of the counter setup, could technically end up at 5.5 
        //if a user backs up partway through. might change this?
        if (counter >= 7 && !isCrashing)
        {
            //Has a bool so it doesn't KEEP CALLING THE SAME CRASH ROUTINE
            isCrashing = true;
            crashGame();
        }
    }

    public void RunDevNote(string name)
    {
        if (!isRunning)
        {
            dialogueRunner.StartDialogue(name);
            isRunning = true;
        }
       
    }

    public void FinishRunning()
    {
        isRunning = false;
    }
}
