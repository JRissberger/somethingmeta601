using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOfSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public void AltarCorrect()
    {
        spriteRenderer.color = Color.green;
    }
}
