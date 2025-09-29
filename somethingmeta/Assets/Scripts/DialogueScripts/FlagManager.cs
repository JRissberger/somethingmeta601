using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn;

public class FlagManager : MonoBehaviour
{
    //unique self, keeps track and makes sure there is only one instance throughout the project.
    public static FlagManager instance;
    enum puzzleFlags
    {
        beastHunter,
        none
    }

    #region BeastHunterFlags_BH
    public Flag[] beastHunterFlags;
    public string bh_currentNode = "BeastHunterIntroduction";
    #endregion

    #region Puzzle2Flags_P2F
    #endregion

    #region Puzzle3Flags_P3F
    #endregion

    #region Puzzle4Flags_P4F
    #endregion

    #region Puzzle5Flags_P5F
    #endregion

    #region Puzzle6Flags_P6F
    #endregion
    
    /// <summary>
    /// Sets all currentNodes for dialogue, creates a Singleton.
    /// </summary>
    private void Awake()
    {
        bh_currentNode = "BeastHunterIntroduction";
        //any new first nodes for dialogue should be added here!
        CreateSingleton();
    }

    /// <summary>
    /// Sets the singleton to self, and makes it so this script transfers between scenes. In the case
    /// that there is another singleton in this scene, it will delete it.
    /// </summary>
    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Scene Transition - [ takes you to the office, and ] takes you to the dialogue testing scene.
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            SceneManager.LoadScene("Office");
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
           SceneManager.LoadScene("DialogueTesting");
        }
    }
}
