using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicnicDevTools : MonoBehaviour
{
#if UNITY_EDITOR

    [SerializeField] PicnicEventManager eventManager;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            eventManager.BunnyDialogue();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            eventManager.PenguinDialogue();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            eventManager.CatDialogue();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            eventManager.FoxDialogue();
        }
    }

#endif
}
