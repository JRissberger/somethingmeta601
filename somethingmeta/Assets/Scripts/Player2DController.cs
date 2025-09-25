using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    //Is the player allowed to move (freeze in dialogue etc)
    public bool canMove { get; set; } = true;

    //Uses a rigidbody bc it's better for 2d movement feel
    private Rigidbody controller;

    private float moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        //Get controller
        controller = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement controls, user must not be in a menu/inspecting an object
        if (canMove)
        {
            //Using X and Y to mimic 2D movement
            //Raw axis to get rid of smoothing, no delay etc
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            //Sets velocity, using normalized to keep diagonals from being faster
            Vector2 movement = new Vector2(x, y).normalized * moveSpeed;
            controller.velocity = movement;

        }
    }
}
