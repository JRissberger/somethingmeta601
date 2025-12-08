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

    //Reference to the fade transition
    FadeTransition fadeTransition = null;

    TransitionManager transitionManager;

    //TODO: If we want any glitch effects, program them here

    private void Start()
    {
        //Both these objects have to be searched for since they're in the office scene
        fadeTransition = GameObject.Find("FadeTransition").GetComponent<FadeTransition>();
        transitionManager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
    }

    //Transitions the scene back to the 3D office
    public void forceShutoff()
    {
        Debug.Log("forceShutoff called");

        //Unload current scene and swap to office
        transitionManager.ReturnToOffice();
        
    }

    public void switchScenes(string sceneName)
    {
        transitionManager.SwitchScenes(sceneName);
    }
    ////Runs the full fade and load transition so the coroutines aren't overlapping and you can actually see the thing fade
    //public IEnumerator SceneTransition()
    //{
    //    //Fade out
    //    //yield return StartCoroutine(fadeTransition.FadeOut());

    //    //Loads scene
    //    yield return StartCoroutine(unloadScene());

    //    //Fade in
    //    //yield return StartCoroutine(fadeTransition.FadeIn());
    //}

    ////Using a corutine to not freeze anything
    ////Unloads the 2D scene, returns to the office
    //private IEnumerator unloadScene()
    //{
    //    Scene officeScene = SceneManager.GetSceneByName(sceneName);

    //    //Enabling office objects since they get disabled when switching scenes
    //    foreach (GameObject gameObject in officeScene.GetRootGameObjects())
    //    {
    //        gameObject.SetActive(true);
    //    }

    //    //Unloading current 2d scene
    //    AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

    //    //Wait until the unload is done
    //    while (!asyncUnload.isDone)
    //    {
    //        yield return null;
    //    }

    //    //Switch back to office
    //    SceneManager.SetActiveScene(officeScene);

    //}

}
