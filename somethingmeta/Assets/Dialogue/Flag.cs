using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Flag")]
public class Flag : ScriptableObject
{

    [SerializeField] private string name;
    [SerializeField] private bool activated = false;


    public void SetActivity(bool active)
    {
        activated = active;
    }

    public bool GetActivity()
    {
        return activated; 
    }

    public string Name()
    {
        return name;
    }
}
