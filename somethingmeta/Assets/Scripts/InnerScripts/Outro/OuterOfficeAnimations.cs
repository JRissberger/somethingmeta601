using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterOfficeAnimations : MonoBehaviour
{

    [SerializeField] Animator MainHands;
    [SerializeField] Light lampLight;
    [SerializeField] GameObject LampTexture;
    [SerializeField] Light TopLight;
    [SerializeField] ForceShutoff forceShutoff;
    // Start is called before the first frame update
    void Start()
    {
        lampLight.enabled = false;
        TopLight.enabled = false;
        StartCoroutine(StartCredits());
    }


    public IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(8f);
        forceShutoff.switchScenes("Credits");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
