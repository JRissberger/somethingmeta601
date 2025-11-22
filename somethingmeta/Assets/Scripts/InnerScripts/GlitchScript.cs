using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class GlitchScript : MonoBehaviour
{
    [SerializeField] public Sprite[] CreatureToFuckUp;
    [SerializeField] private Sprite[] CreatureToFuckDown;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Scramble();
        }
    }

    public void Scramble()
    {
        Debug.Log(CreatureToFuckUp.);
    }
}
