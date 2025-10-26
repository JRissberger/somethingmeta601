using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Yarn.Unity;

public class PicnicEventManager : MonoBehaviour
{

    //Dialogue Nodes, sprite, and boolean for Bunny Character
    [Header("Bunny Dialogue")]
    public string bunnyGenericNode;
    public string bunnyCorrectNode;
    public string bunnyIncorrectNode;
    private bool bunnyHappy = false;
    [SerializeField] private SpriteRenderer bunnySprite;

    //Dialogue Nodes, sprite, and boolean for Penguin Character
    [Header("Penguin Dialogue")]
    public string penguinGenericNode;
    public string penguinCorrectNode;
    public string penguinIncorrectNode;
    private bool penguinHappy = false;
    [SerializeField] private SpriteRenderer penguinSprite;

    //Dialogue Nodes, sprite, and boolean for Cat Character
    [Header("Cat Dialogue")]
    public string catGenericNode;
    public string catCorrectNode;
    public string catIncorrectNode;
    private bool catHappy = false;
    [SerializeField] private SpriteRenderer catSprite;

    //Dialogue Nodes, sprite, and boolean for Fox Character
    [Header("Fox Dialogue")]
    public string foxGenericNode;
    public string foxCorrectNode;
    public string foxIncorrectNode;
    private bool foxHappy = false;
    [SerializeField] private SpriteRenderer foxSprite;

    //Squirrel dialogue
    [SerializeField] private string SquirrelNode;
    //dead rabbit sprite
    [SerializeField] private Sprite deadRabbit;
    //inventory visual
    [SerializeField] private Canvas inventoryCanvas;

    //YarnSpinner DialogueRunner
    public DialogueRunner DialogueRunner;
    //checks if dialogue is currently running
    private bool isDialogueRunning = false;

    //Runs when forceReturn is called
    [SerializeField] private UnityEvent forceReturn;
    //flag that checks if the player is at the computer.
    [SerializeField] private Flag officeShutoff;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Load2DScene();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void BunnyDialogue()
    {
        if (isDialogueRunning == false)
        {
            if (bunnyHappy)
            {
                DialogueRunner.StartDialogue(bunnyCorrectNode);
            }
            else
            {
                DialogueRunner.StartDialogue(bunnyGenericNode);
            }
            isDialogueRunning = true;
        }
    }

    public void BunnyUnhappy()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(bunnyIncorrectNode);
            isDialogueRunning = true;
        }
    }

    public void BunnyGivenItem()
    {
        bunnyHappy = true;
        DialogueRunner.StartDialogue(bunnyCorrectNode);
    }


    public void FoxDialogue()
    {
        if (isDialogueRunning == false)
        {
            if (foxHappy)
            {
                DialogueRunner.StartDialogue(foxCorrectNode);
            }
            else
            {
                DialogueRunner.StartDialogue(foxGenericNode);
            }
            isDialogueRunning = true;
        }
    }

    public void FoxUnhappy()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(foxIncorrectNode);
            isDialogueRunning = true;
        }
    }

    public void FoxGivenItem()
    {
        foxHappy = true;
        DialogueRunner.StartDialogue(foxCorrectNode);
    }

    public void PenguinDialogue()
    {
        if (isDialogueRunning == false)
        {
            if (penguinHappy)
            {
                DialogueRunner.StartDialogue(penguinCorrectNode);
            }
            else
            {
                DialogueRunner.StartDialogue(penguinGenericNode);
            }
            isDialogueRunning = true;
        }
    }

    public void PenguinUnhappy()
    {
        if (isDialogueRunning == false)
        {
            Debug.Log("THIS IS RUNNING");
            DialogueRunner.StartDialogue(penguinIncorrectNode);
            isDialogueRunning = true;
        }
    }

    public void PenguinGivenItem()
    {
        penguinHappy = true;
        DialogueRunner.StartDialogue(penguinCorrectNode);
    }

    public void CatDialogue()
    {
        if (isDialogueRunning == false)
        {
            if (catHappy)
            {
                DialogueRunner.StartDialogue(catCorrectNode);
            }
            else
            {
                DialogueRunner.StartDialogue(catGenericNode);
            }
            isDialogueRunning = true;
        }

    }
    public void CatUnhappy()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(catIncorrectNode);
            isDialogueRunning = true;
        }
    }

    public void CatGivenItem()
    {
        catHappy = true;
        DialogueRunner.StartDialogue(catCorrectNode);
    }

    public void ResetDialogueBool()
    {
        isDialogueRunning = false;
    }

    public void SquirrelGeneric()
    {
        if (isDialogueRunning == false)
        {
            DialogueRunner.StartDialogue(SquirrelNode);
            isDialogueRunning = true;
        }
    }

    public void CorruptPicnic()
    {
        //kill me
        bunnySprite.sprite = deadRabbit;
        bunnySprite.gameObject.transform.localScale = (bunnySprite.size * new Vector3(0.5f, 0.5f, 0.5f));
        penguinSprite.sprite = deadRabbit;
        penguinSprite.gameObject.transform.localScale = (penguinSprite.size * new Vector3(0.5f, 0.5f, 0.5f));
        catSprite.sprite = deadRabbit;
        catSprite.gameObject.transform.localScale = (catSprite.size * new Vector3(0.5f, 0.5f, 0.5f));
        foxSprite.sprite = deadRabbit;
        foxSprite.gameObject.transform.localScale = (foxSprite.size * new Vector3(0.5f, 0.5f, 0.5f));

        StartCoroutine(DeleteScene(0.45f));

    }

    private IEnumerator DeleteScene(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        bunnySprite.gameObject.SetActive(false);
        penguinSprite.gameObject.SetActive(false);
        catSprite.gameObject.SetActive(false);
        foxSprite.gameObject.SetActive(false);
        yield return new WaitForSeconds(delayTime);
        Load2DScene();
    }

    

    public void HideInventory()
    {
        inventoryCanvas.enabled = false;
    }

    public void ShowInventory()
    {
        inventoryCanvas.enabled = true;
    }

    public void Load2DScene()
    {
        //Makes sure the component was gotten
       
            //Tries to load the corresponding scene
            try
            {
                SceneManager.LoadScene("Office");
            }
            //TODO: response to player for invalid code
            catch
            {
                Debug.Log("Invalid code");
            }
        
        
    }

}
