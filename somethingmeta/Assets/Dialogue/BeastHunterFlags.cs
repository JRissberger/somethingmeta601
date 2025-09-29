using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Legacy;

public class BeastHunterFlags : MonoBehaviour
{
    //A bunch of bools that is checked
    [SerializeField] private DialogueRunner dialogue;
    [SerializeField] private string levelLoaded;

    private string bh_eyesNoticed = "bh_eyesNoticed";
    private string bh_clawsNoticed = "bh_clawsNoticed";
    private string bh_behindYou = "bh_eyesNoticed";

    [YarnCommand("SetLatestNode")]
   public void SetLatestNode()
    {
        dialogue.onNodeStart.AddListener(SetNewStartNode);
        
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

    [YarnCommand("SetFlag")]
    public void SetFlag(string flag)
    {
        
    }



    //all incorrect options cannot cut to a new node.
}
