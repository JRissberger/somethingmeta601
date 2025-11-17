using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDevTools : MonoBehaviour
{

    [SerializeField] private Transform basePosition;
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) )
            {
            Debug.Log("Player Moved to base position");
            player.position = basePosition.position;
        }
    }
}
