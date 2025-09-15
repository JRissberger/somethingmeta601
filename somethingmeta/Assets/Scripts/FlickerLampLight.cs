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
        Debug.Log("Behold! The light has been the flicked!");
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
