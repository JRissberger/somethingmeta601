using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransition : MonoBehaviour
{
    //Canvas group element has the alpha value being edited
    [SerializeField] CanvasGroup canvas;
    [SerializeField] float fadeLength = 0.3f;

    //Fades out the cover (fades in the scene)
    public IEnumerator FadeIn()
    {
        Debug.Log("fading in");
        float timer = fadeLength;

        //While the timer's going, edit the alpha value
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            canvas.alpha = timer / fadeLength;
            yield return null;
        }

        //If for whatever reason alpha isn't 0, manually set it
        canvas.alpha = 0;
    }

    //Fade in the cover (fades out the scene)
    public IEnumerator FadeOut()
    {
        float timer = fadeLength;

        //While the timer's going, edit the alpha value
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            canvas.alpha = 1 - (timer / fadeLength);
            yield return null;
        }

        //If for whatever reason alpha isn't 1, manually set it
        canvas.alpha = 1;
    }
}

