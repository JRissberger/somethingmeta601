using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLabyrinthTrigger : MonoBehaviour
{
    //Reference to the labyrinth manager to call methods
    [SerializeField] private LabyrinthManager manager;

    //Calls the manager counter iteration if a threshold is walked over
    //NOTE: NEED TO TAG OBJECTS WITH THRESHOLD TAG
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Threshold"))
        {
            manager.increaseCounter();
        }
    }
}
