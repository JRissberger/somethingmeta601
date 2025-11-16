using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockboxManager : MonoBehaviour
{
    //References to the three individual numbers
    [SerializeField] private LockboxNumber number1;
    [SerializeField] private LockboxNumber number2;
    [SerializeField] private LockboxNumber number3;

    //The correct numbers
    //This is kept as a string for ease of checking due to putting together the 3 numbers
    //Please don't put letters here. I'll cry
    [SerializeField] private string correctSequence;

    //Events to run when all numbers are correct
    [SerializeField] private UnityEvent unlock;

    //Keep the event from running EVERY FRAME once unlocked
    private bool isUnlocked = false;

    // Update is called once per frame
    void Update()
    {
        checkNumbers();
    }

    //Checks if all three numbers match
    private void checkNumbers()
    {
        //Combine the three individual numbers
        //They're strings, so they're concatenating not being added
        string inputSequence = number1.Number.ToString() + number2.Number.ToString() + number3.Number.ToString();

        if (inputSequence == correctSequence && !isUnlocked)
        {
            unlock.Invoke();
            isUnlocked = true;
        }
    }

    
    //Debug method to run when unlocked
    public void unlocked()
    {
        Debug.Log("Lockbox unlocked");
    }

}
