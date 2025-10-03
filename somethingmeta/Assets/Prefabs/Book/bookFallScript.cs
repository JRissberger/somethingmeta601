using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookFallScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Flag beastHunterDead;
    [SerializeField] private InteractableObject interactableObject;
    // Start is called before the first frame update
    public void MakeBookFall()
    {
        interactableObject.enabled = true;
        animator.SetBool("bookFall", true);
    }

    public void Start()
    {
        interactableObject.enabled = false;
        if (beastHunterDead.GetActivity() == true)
        {
            MakeBookFall();
        }
    }
}
