using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Flag")]
public class Flag : ScriptableObject
{
    [Tooltip("The name of the flag - the object name might be different.")]
    [SerializeField] private string name;
    [Tooltip("Whether or not the flag has been activated.")]
    [SerializeField] private bool activated = false;

    /// <summary>
    /// Sets the value of activated to the boolean parameter.
    /// </summary>
    /// <param name="active"></param>
    public void SetActivity(bool active)
    {
        activated = active;
    }

    /// <summary>
    /// Returns the bool value of activated.
    /// </summary>
    /// <returns></returns>
    public bool GetActivity()
    {
        return activated; 
    }

    /// <summary>
    /// Returns string name of the flag.
    /// </summary>
    /// <returns></returns>
    public string Name()
    {
        return name;
    }
}
