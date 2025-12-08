using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRedness : MonoBehaviour
{
    // Start is called before the first frame update
    bool isRed = false;



    // Update is called once per frame
    void Update()
    {
        if (isRed)
        {
            isRed = false;
        }
        if (Random.Range(0f, 1f) > 0.9f)
        {
            isRed = true;
        }

        if (isRed)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
        }
        
    }
}
