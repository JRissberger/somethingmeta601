using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{

    [SerializeField] private FlagManager instance;

    #region BeastHunterFlags_BH
    public bool bh_eyesNoticed;
    public bool bh_clawsNoticed;
    public bool bh_behindYou;
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
