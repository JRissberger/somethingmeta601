using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLampLight : MonoBehaviour
{
    [SerializeField] Light lampLight;
    private bool isOn;

    private void Start()
    {
        isOn = true;
    }

    // Update is called once per frame
    public void SwitchLight()
    {
        
        if (isOn)
        {
            lampLight.enabled = false;
            isOn = false;
        }
        else
        {
            lampLight.enabled = true;
            isOn = true;
        }
    }
}
