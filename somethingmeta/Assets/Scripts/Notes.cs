using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class Notes : MonoBehaviour
{
    /*
     * UI outline: main area is a text field that's dynamically updated with the array value.
     * Default if the array is empty is "no notes"
     * This should be set up when the menu is opened.
     * Next/Previous will pull the next index value and update the text field value with that.
     * There will be a persistent index value, this is checked with next/previous to ensure it rolls over.
     * TODO: scrolling? how to handle long notes 
     */

    //Notes UI
    [SerializeField] private GameObject notesMenu;
    private bool notesActive = false;

    //Stores all the notes 
    private List<string> notes = new List<string>();
    private int currentIndex = 0;

    //References to the individual UI elements
    Transform nextButton;
    Transform previousButton;
    Transform createButton;
    Transform deleteButton;
    Transform saveButton;
    Transform backButton;
    Transform textField;
    Transform inputField;

    void Start()
    {
        //Retrieve references to all the UI elements
        nextButton = notesMenu.transform.Find("Next");
        previousButton = notesMenu.transform.Find("Previous");
        createButton = notesMenu.transform.Find("New");
        deleteButton = notesMenu.transform.Find("Delete");
        saveButton = notesMenu.transform.Find("Save");
        backButton = notesMenu.transform.Find("Back");
        textField = notesMenu.transform.Find("NoteContent");
        inputField = notesMenu.transform.Find("NotesInput");

    }
    //Toggle notes menu
    public void NoteToggle()
    {
        if (!notesActive)
        {
            //Update the text field with the current note

            notesMenu.SetActive(true);
            notesActive = true;

            //Manually disable the note entry buttons
            //TODO: make an array to loop for this
            //saveButton.gameObject.SetActive(false);
            //backButton.gameObject.SetActive(false);
            //inputField.gameObject.SetActive(false);

            Debug.Log(saveButton);

        }
        else
        {
            notesMenu.SetActive(false);
            notesActive = false;
        }
    }

    //Creates new note
    public void createNote()
    {
        Debug.Log("Create note");

        //Switch active display to text input (can be done with toggling active/inactive ui parts)
        //Needs to have a back button and a save button

        //TODO: using 

    }

    //Saves the created note when save button is pressed
    public void saveNote()
    {
        Debug.Log("Save note");
        //Get the text input value
        //Add it to the list
        //Switch display back to the notes list (toggle active/inactive parts)
    }

    //Deletes current note
    public void deleteNote()
    {
        Debug.Log("Delete note");

        //Remove at the current index
        //Update the text field with the previous note (or wipe if there's none)
    }

    //Cycles through notes
    public void NextNote()
    {
        Debug.Log("Next note");

        //Iterate index by one
        //If the index is greater than list count - 1, set to 0
        //Update text field with the new note
    }
    public void PreviousNote()
    {
        Debug.Log("Previous note");

        //Iterate index by -1 
        //If the index goes to negatives, roll over to list count - 1
        //Update the text field with the new note
    }
}
