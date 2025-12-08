using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    //Handles scene transitions and fade in/fade out
    //This is all in a separate script so it can be attached to an object that doesn't get disabled partway through

    [SerializeField] FadeTransition fadeTransition;

    //Audio for returning to the office
    [SerializeField] AudioSource computerOffAudio;

    //Only run one scene switch at a time!
    //Prevents "mitosis" bug of loading multiple copies of the same scene
    public bool inTransition { get; private set; } = false;

    public void SwitchScenes(string sceneName)
    {
        StartCoroutine(SceneTransition(sceneName));
    }

    //Runs the full fade and load transition so the coroutines aren't overlapping and you can actually see the thing fade
    public IEnumerator SceneTransition(string sceneName)
    {
        //Prevent new transitions from starting while this is running
        inTransition = true;

        //Fade out
        yield return StartCoroutine(fadeTransition.FadeOut());

        //Loads scene
        yield return StartCoroutine(LoadSceneAsync(sceneName));

        //Fade in
        yield return StartCoroutine(fadeTransition.FadeIn());

        inTransition = false;
    }

    //Returns to office (no loading since it already existsF)
    public void ReturnToOffice()
    {
        StartCoroutine(OfficeTransition());
    }

    public IEnumerator OfficeTransition()
    {
        //Fade out
        yield return StartCoroutine(fadeTransition.FadeOut());

        //Loads scene
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        yield return SceneManager.SetActiveScene(SceneManager.GetSceneByName("Office"));

        //Re enable everything
        foreach(GameObject gameObject in SceneManager.GetSceneByName("Office").GetRootGameObjects())
        {
            gameObject.SetActive(true);
        }

        //Fade in
        yield return StartCoroutine(fadeTransition.FadeIn());
    }

    public void GoToFinal()
    {
        StartCoroutine(FinalOfficeTransition());
    }

    public IEnumerator FinalOfficeTransition()
    {
        //Fade out
        yield return StartCoroutine(fadeTransition.FadeOut());

        //Loads scene
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        yield return SceneManager.SetActiveScene(SceneManager.GetSceneByName("Office"));

        //Re enable everything
        foreach (GameObject gameObject in SceneManager.GetSceneByName("Office").GetRootGameObjects())
        {
            gameObject.SetActive(true);
        }

        //Fade in
        yield return StartCoroutine(fadeTransition.FadeIn());
    }
    //Coroutine loads scene in background
    //Means Load2DScene can wait for the load to finish before swapping scenes
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        //Loop until the scene is loaded
        while (!asyncLoadScene.isDone)
        {
            yield return null;
        }

        //Hiding every object in the current scene
        foreach (GameObject gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (gameObject.name != "NotesUI" && gameObject.name != "FadeTransition" && gameObject.name != "TransitionManager")
            {
                gameObject.SetActive(false);
            }
        }

        //Swap to the new scene
        //Have to search for the scene by name since setActiveScene needs a Scene object
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}
