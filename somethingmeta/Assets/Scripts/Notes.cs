using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class Notes : MonoBehaviour
{
    /*
     * UI outline: main area is a text field that's dynamically updated with the array value.
     * Default if the array is empty is "no notes"
     * This should be set up when the menu is opened.
     * Next/Previous will pull the next index value and update the text field value with that.
     * There will be a persistent index value, this is checked with next/previous to ensure it rolls over.
     * TODO: scrolling? how to handle long notes 
     * TODO: down the line I may switch this to be two full menus that are toggled between
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

    private TMP_InputField textInput;
    private TMP_Text textDisplay;

    void Start()
    {
        //Retrieve references to all the UI elements
        nextButton = notesMenu.transform.Find("NotesMenu/Next");
        previousButton = notesMenu.transform.Find("NotesMenu/Previous");
        createButton = notesMenu.transform.Find("NotesMenu/New");
        deleteButton = notesMenu.transform.Find("NotesMenu/Delete");
        saveButton = notesMenu.transform.Find("NotesMenu/Save");
        backButton = notesMenu.transform.Find("NotesMenu/Back");
        textField = notesMenu.transform.Find("NotesMenu/NoteContent");
        inputField = notesMenu.transform.Find("NotesMenu/NotesInput");

        textInput = inputField.GetComponent<TMP_InputField>();
        textDisplay = textField.GetComponent<TMP_Text>();
    }
    //Toggle notes menu
    public void NoteToggle()
    {
        if (!notesActive)
        {
            //Update the text field with the current note
            notesMenu.SetActive(true);
            notesActive = true;
            if (notes.Count > 0)
            {
                textDisplay.text = notes[currentIndex];
            }
            else
            {
                textDisplay.text = "No notes";
            }

            //Manually disable the note entry buttons
            //TODO: make an array to loop for this
            saveButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
            inputField.gameObject.SetActive(false);

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

        //Switch active display to text input (can be done with toggling active/inactive ui parts)
        //Needs to have a back button and a save button

        //TODO: make a list to loop through this
        //Hides main note menu
        nextButton.gameObject.SetActive(false);
        previousButton.gameObject.SetActive(false);
        createButton.gameObject.SetActive(false);
        deleteButton.gameObject.SetActive(false);
        textField.gameObject.SetActive(false);

        //Displays creation menu
        saveButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        inputField.gameObject.SetActive(true);

    }

    //Saves the created note when save button is pressed
    //TODO: big bug where n hotkey while typing will close menu
    //May need a bool passed back to player
    //Or we'll have a persistent UI button instead idk
    public void saveNote()
    {
        
        //Only save if there's text
        if (textInput.text != "")
        {
            //Get the text input value
            //Add it to the list
            notes.Add(textInput.text);

            //Clears input field
            textInput.text = "";

            //Switch display back to the notes list (toggle active/inactive parts)
            //Call the back() method to return to main page
            back();
        }
    }

    //Return to main note page
    public void back()
    {
        //Shows main note menu
        nextButton.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(true);
        createButton.gameObject.SetActive(true);
        deleteButton.gameObject.SetActive(true);
        textField.gameObject.SetActive(true);

        //Hides creation menu
        saveButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);

        //If the note count was empty (now at 1), update text
        //This is since otherwise, there's no point where the text field would've been prompted to update
        if (notes.Count == 1)
        {
            textDisplay.text = notes[0];
        }
    }

    //Deletes current note
    public void deleteNote()
    {
        Debug.Log("Delete note");

        //Remove at the current index
        if (notes.Count > 0)
        {
            notes.RemoveAt(currentIndex);
        }

        //Decreases index by 1 if there's any notes left
        if(currentIndex > 0)
        {
            currentIndex--;
        }

        //Update the text field with the previous note (or wipe if there's none)
        if (notes.Count > 0)
        {
            textDisplay.text = notes[currentIndex];
        }
        else
        {
            textDisplay.text = "No notes";
        }
    }

    //Cycles through notes
    public void nextNote()
    {

        if (notes.Count > 0)
        {
            //Iterate index by one
            //If the index is greater than list count - 1, set to 0
            if (currentIndex < notes.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }

            //Update the text field
            textDisplay.text = notes[currentIndex];
        }
    }
    public void previousNote()
    {

        if (notes.Count > 0)
        {
            //Iterate index by -1 
            //If the index goes to negatives, roll over to list count - 1
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = notes.Count - 1;
            }

            //Update the text field with the new note
            textDisplay.text = notes[currentIndex];
        }
    }
}
