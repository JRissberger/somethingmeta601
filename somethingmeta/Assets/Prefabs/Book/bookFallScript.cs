using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookFallScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Flag beastHunterDead;
    // Start is called before the first frame update
    public void MakeBookFall()
    {
        animator.SetBool("bookFall", true);
    }

    public void Start()
    {
        if (beastHunterDead.GetActivity() == true)
        {
            MakeBookFall();
        }
    }
}
