using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class AL_PondScript : MonoBehaviour
{

    [SerializeField] private DialogueRunner dialogue;
    [SerializeField] private ForceShutoff forceShutoff;
    //Canvas with the crash info
    [SerializeField] private GameObject crashScreen;

    [SerializeField] private AudioSource crashSound;

    // Start is called before the first frame update
    public void StartDialogue(string name)
    {
        dialogue.StartDialogue(name);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            forceShutoff.forceShutoff();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            crashGame();
        }
    }

    //Switch to crash screen, then forcequit
    //Enable crash panel, wait X amount of seconds
    public void crashGame()
    {
        if (crashSound != null)
        {
            Debug.Log("Playing sound");
            crashSound.Play();
        }
        crashScreen.SetActive(true);
        StartCoroutine(waitTransition());
    }

    //Using a coroutine to wait a set time before switching back to office
    private IEnumerator waitTransition()
    {
        yield return new WaitForSeconds(3f);
        forceShutoff.forceShutoff();
    }

    //public void Load2DScene()
    //{
    //    //Makes sure the component was gotten

    //    //Tries to load the corresponding scene
    //    try
    //    {
    //        SceneManager.LoadScene("Office");
    //    }
    //    //TODO: response to player for invalid code
    //    catch
    //    {
    //        Debug.Log("Invalid code");
    //    }


    //}
}
