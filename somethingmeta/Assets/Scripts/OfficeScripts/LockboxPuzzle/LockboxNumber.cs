using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockboxNumber : MonoBehaviour
{
    //The current number
    private int number = 0;

    //Needs to be accessible by the manager
    public int Number { get { return number; } }

    //Reference to the text display to update
    [SerializeField] private TMP_Text numberText;

    //Increases the number by 1 when clicked
    public void IterateNumber()
    {
        //Roll back to 0 if at 9
        if (number == 9)
        {
            number = 0;
        }
        else
        {
            number++;
        }

        //Update the number display
        numberText.text = number.ToString();
    }

}
