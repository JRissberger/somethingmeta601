using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] private GameObject horrorBits;
    [SerializeField] private GameObject properCredits;
    [SerializeField] private ForceShutoff force;
    public void SwitchToCredits()
    { 
        StartCoroutine(StartCredits());
    }

    public void Start()
    {
        SwitchToCredits();
    }

    public IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(7f);
        horrorBits.SetActive(true);
        properCredits.SetActive(true);

        yield return new WaitForSeconds(10f);

        force.switchScenes("Main Menu");
    }
}
