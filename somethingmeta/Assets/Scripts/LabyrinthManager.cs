using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthManager : MonoBehaviour
{
    //All the triggers for crossing a threshold. 
    //TODO: may change this to get the gameobject and look at its children
    //Will depend on how assets are set up
    [SerializeField] private List<BoxCollider2D> triggers;

    //Counter for how many times the player has crossed a threshold
    //Crashes the game if it's at 6
    private int counter = 0;

    //Loops to check for any triggers

    //Increments the counter
    public void increaseCounter()
    {
        counter += 1;
        Debug.Log(counter);
    }

    //Resets the counter
    //Used when interacting with an object in the labyrinth
    public void resetCounter()
    {
        counter = 0;
    }

    //Switch to crash screen, then forcequit
    //Enable crash panel, wait X amount of seconds
    private void crashGame()
    {

    }

    private void Update()
    {
        //Checks what the counter's at
        if (counter >= 6)
        {
            crashGame();
        }
    }
}
