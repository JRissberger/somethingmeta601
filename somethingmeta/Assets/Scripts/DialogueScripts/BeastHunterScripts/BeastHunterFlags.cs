using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Legacy;

public class BeastHunterFlags : MonoBehaviour
{
    //The dialogue runner
    [SerializeField] private DialogueRunner dialogue;
    [SerializeField] private Flag officeShutDown;
    [SerializeField] private Flag beastHunterDead;
    [SerializeField] private GameObject beastHunterSprite;
    [SerializeField] private GameObject beastHunteDeadrSprite;

    //Event system--generally going to be used to call forceShutoff
    [SerializeField] private UnityEvent forceReturn;

    //The node that the dialogue will restart from
    private string currentNode;
    //All flags that are relevant to the beast hunter puzzle, pulls from the FlagManager Singleton.
    private static Flag[] allFlags;

    /// <summary>
    /// Used on awake to set a listener to use and store the most recent node for future use.
    /// </summary>
    [YarnCommand("SetLatestNode")]
   public void SetLatestNode()
    {
        dialogue.onNodeStart.AddListener(SetNewStartNode);
    }

    /// <summary>
    /// Finds the newest node in use, sets that value in FlagManager. Next time this scene is loaded, it will use this node when it starts.
    /// </summary>
    /// <param name="nodeName"></param>
    public void SetNewStartNode(string nodeName)
    {
        currentNode = nodeName;
        //sets the current node of the puzzle to the node received.
        FlagManager.instance.bh_currentNode = currentNode;
        //also uses this node as the start node.
        dialogue.startNode = nodeName;

    }


    private void Awake()
    {

        SetLatestNode();
        //same thing as SetNewStartNode, but on awake. NOTE that a default node is within the FlagManager.
        dialogue.startNode = FlagManager.instance.bh_currentNode;

        if (beastHunterDead.GetActivity() == true)
        {
            dialogue.startNode = "BeastHunterDead";
        }

        //sets allFlags to BeastHunterFlags from the FlagManager
        allFlags = FlagManager.instance.beastHunterFlags;
        // Create a new command called 'setFlag' which sets a flag to the bool. Usable in Yarnspinner.
        
        dialogue.AddCommandHandler<string, bool>(
            "SetFlag",     // the name of the command
            SetFlag); // the method to run
        

    }

    private void Start()
    {
        officeShutDown.SetActivity(true);
        if (beastHunterDead.GetActivity() == true)
        {
            beastHunterSprite.SetActive(false);
            beastHunteDeadrSprite.SetActive(true);
            
        }
        
    }

    public void Update()
    {
        

        //For testing purposes - comment this out when it is no longer necessary.

        //when 0 is pressed, the dialogue starts again.
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            dialogue.StartDialogue(currentNode);
        }
        //when 9 is pressed, immediately end the dialogue.
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            //levelLoaded = dialogue.
            dialogue.Stop();
        }
    }

    //[YarnCommand("SetFlag")]
    /// <summary>
    /// Sets a flag to the value (bool).
    /// </summary>
    /// <param name="flag">string name of the flag.</param>
    /// <param name="value">whether the flag is on or not.</param>
    public static void SetFlag(string flag, bool value)
    {
        for (int i = 0; i < allFlags.Length; i++)
        {
            Debug.Log(allFlags[i]); 
            if (allFlags[i].name.ToLower() == flag.ToLower())
            {
                allFlags[i].SetActivity(value);
                break;
            }
        }
    }

    /// <summary>
    /// Returns the flag value of the flag.
    /// </summary>
    /// <param name="flag">string name of the flag.</param>
    /// <returns></returns>
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

    /// <summary>
    /// Sets the scene to the Office Scene.
    /// </summary>
    [YarnCommand("3DScene")]
    public void SwitchScene()
    {
        forceReturn.Invoke();
    }


}
