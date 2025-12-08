using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBunnyAltar : MonoBehaviour
{
    private int totalCorrect;
    [SerializeField] private GameObject bunnyAltar;
    [SerializeField] private GameObject numbers;
    public void Start()
    {
        totalCorrect = 0;
    }

    public void CheckCount()
    {
        totalCorrect++;
        if (totalCorrect == 3)
        {
            bunnyAltar.SetActive(true);
            numbers.SetActive(true);
        }
    }
}
