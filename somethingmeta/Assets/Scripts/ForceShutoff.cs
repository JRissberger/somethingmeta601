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
        //Update the force shutoff flag
        FlagManager.instance.officeFlags[0].SetActivity(true);

        SceneManager.LoadScene(sceneName);
    }

}
