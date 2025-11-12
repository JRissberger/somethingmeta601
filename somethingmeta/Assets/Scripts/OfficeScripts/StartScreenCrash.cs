using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenCrash : MonoBehaviour
{
    public void ShowCrash()
    {
        this.gameObject.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }
    }
}
