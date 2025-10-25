using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicnicFlagManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Flag finishedPicnic;

    //bools that monitor whether each character has gotten their food.
    public bool bunnyHappy { get;  set; }
    public bool penguinHappy { get; set; }
    public bool catHappy { get; set; }
    public bool foxHappy { get; set; }

    [SerializeField] private PicnicEventManager PicnicEventManager;

    private void Awake()
    {
        bunnyHappy = false;
        penguinHappy = false;
        catHappy = false;
        foxHappy = false;
    }

   
    public void CheckIfPicnicFinish()
    {
        if (bunnyHappy && penguinHappy && catHappy && foxHappy)
        {
            PicnicEventManager.CorruptPicnic();
        }
    }

    
}
