using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TESTING_EasyTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadDialogue()
    {
        SceneManager.LoadScene("DialogueTesting");
    }
}
