using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceShutoff : MonoBehaviour
{
    //Name of the scene to transition to
    [SerializeField] private string sceneName = "Office";

    //Get the character once the scene has changed
    private PlayerController player;

    //TODO: If we want any glitch effects, program them here

    //Transitions the scene back to the 3D office
    public void forceShutoff()
    {
        SceneManager.LoadScene(sceneName);
        setPlayerPosition();
    }

    //Sets the player in the 3D scene to be in front of the computer
    public void setPlayerPosition()
    {
        //Get a reference to the player
    }

}
