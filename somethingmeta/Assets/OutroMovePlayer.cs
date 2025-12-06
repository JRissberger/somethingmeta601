using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroMovePlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void MovePlayer(Transform newPosition)
    {
        player.transform.position = newPosition.position;
    }
}
