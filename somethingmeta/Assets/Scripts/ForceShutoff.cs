using System;
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
        Debug.Log("forceShutoff called");
        //Update the force shutoff flag NOTE: likely deprecated
        //FlagManager.instance.officeFlags[0].SetActivity(true);

        //Unload current scene and swap to office
        StartCoroutine(unloadScene());

    }

    //Using a corutine to not freeze anything
    //Unloads the 2D scene, returns to the office
    private IEnumerator unloadScene()
    {
        Scene officeScene = SceneManager.GetSceneByName(sceneName);

        //Enabling office objects since they get disabled when switching scenes
        foreach (GameObject gameObject in officeScene.GetRootGameObjects())
        {
            gameObject.SetActive(true);
        }

        //Unloading current 2d scene
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        //Wait until the unload is done
        while (!asyncUnload.isDone)
        {
            yield return null;
        }

        //Switch back to office
        SceneManager.SetActiveScene(officeScene);

    }

}
