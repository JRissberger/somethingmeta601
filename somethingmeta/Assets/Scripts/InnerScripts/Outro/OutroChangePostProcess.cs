using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OutroChangePostProcess : MonoBehaviour
{
    [SerializeField] Volume profile;
    [SerializeField] ColorAdjustments colorAdjustments;

    [SerializeField] public float startingGandBVal = 255f;
    public void Start()
    {
    }
    public void WorsenStatic()
    {
        if (profile.profile.TryGet<FilmGrain>(out var grain))
        {
            grain.intensity.overrideState = true;
            grain.intensity.value += .2f;
        }
        startingGandBVal -= 20;
        if (profile.profile.TryGet<LensDistortion>(out var colorAdjustments))
        {
            colorAdjustments.intensity.overrideState = true;
            colorAdjustments.intensity.value += .05f;

        }
   }
}
