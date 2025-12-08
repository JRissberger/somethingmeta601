using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookFallScript : MonoBehaviour
{
    [SerializeField] private Flag beastHunterDead;
    [SerializeField] private GameObject LabyrinthStart;
    // Start is called before the first frame update
    public void MakeBookFall()
    {
        LabyrinthStart.SetActive(true);
    }

    public void OnEnable()
    {
        LabyrinthStart.SetActive(false);
        if (beastHunterDead.GetActivity() == true)
        {
            MakeBookFall();
        }
    }
}
