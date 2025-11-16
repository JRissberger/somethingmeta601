using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    //Reference to player
    [SerializeField] Player2DController player;

    //Z axis for the camera should be consistent
    private float z = -8;

    //New camera position
    private Vector3 position = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: check location of rigidbodies, if within a certain distance, don't update
        //Update location based on player
        position = new Vector3(player.transform.position.x, player.transform.position.y, z);
        transform.position = position;
    }
}
