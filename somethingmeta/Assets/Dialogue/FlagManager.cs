using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{

    public static FlagManager instance;
    enum puzzleFlags
    {
        beastHunter,
        none
    }

    #region BeastHunterFlags_BH
    public Flag[] beastHunterFlags;
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

    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
