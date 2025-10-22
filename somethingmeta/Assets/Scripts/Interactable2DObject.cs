using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable2DObject : MonoBehaviour
{
    //Controller for input
    Player2DController player = null;
    [SerializeField] private UnityEvent OnKeyPress;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player2DController>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: depth requirement
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnKeyPress.Invoke();
        }
    }
}
