using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Legacy;

public class BeastHunterFlags : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogue;
    
    [SerializeField] private string levelLoaded;
    private static Flag[] allFlags;

    [YarnCommand("SetLatestNode")]
   public void SetLatestNode()
    {
        dialogue.onNodeStart.AddListener(SetNewStartNode);
        
    }

    private void Awake()
    {
        allFlags = FlagManager.instance.beastHunterFlags;
        // Create a new command called 'camera_look', which looks at a target. 
        // Note how we're listing 'GameObject' as the parameter type.
        dialogue.AddCommandHandler<string, bool>(
            "SetFlag",     // the name of the command
            SetFlag); // the method to run
    }

    private void SetNewStartNode(string nodeName)
    {
        dialogue.startNode = nodeName;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            dialogue.StartDialogue(levelLoaded);
        }
    }

    //[YarnCommand("SetFlag")]
    public static void SetFlag(string flag, bool value)
    {
        for (int i = 0; i < allFlags.Length; i++)
        {
            if (allFlags[i].name.ToLower() == flag.ToLower())
            {
                allFlags[i].SetActivity(value);
                break;
            }
        }
    }

    [YarnFunction("GetFlag")]
    public static bool GetFlag(string flag)
    {
        UnityEngine.Debug.Log("THIS IS RUNNING");
        Debug.Log(flag);
        for (int i = 0; i < allFlags.Length; i++)
        {
            if (allFlags[i].name.ToLower() == flag.ToLower())
            {
                Debug.Log(allFlags[i].GetActivity());
                return allFlags[i].GetActivity();
            }
        }
        //Make sure it does not reach this.
        return true;
    }

    [YarnCommand("3DScene")]
    public static void SwitchScene()
    {
        SceneManager.LoadScene("Office");
    }

    //all incorrect options cannot cut to a new node.
}
