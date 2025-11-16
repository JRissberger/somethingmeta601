using Unity.VisualScripting;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation = 0;
    float yRotation = 0;

    public bool isLooking;

    private Transform player = null;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        isLooking = false;
        
        player = GameObject.FindWithTag("Player").transform;
        Debug.Log(player);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isLooking)
        {
            isLooking=true;
        }

        else if (Input.GetMouseButtonUp(1) && isLooking)
        {
            isLooking=false;
        }

        if (isLooking)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;

            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;


            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);


            //rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        }

        //Rotate player to match
        player.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
