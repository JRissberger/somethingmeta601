using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outro : MonoBehaviour
{

    [SerializeField] private ForceShutoff shutoffScript;
    


    public void RunFinalScene()
    {
        StartCoroutine(ChangeScene());
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        shutoffScript.switchScenes("OfficeFinal");
    }
}
