using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorSpriteRenderer : ColorComponent
{
    [HideInInspector] [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        this.ValidateComponent(ref spriteRenderer);
    }

    public override Color GetColor()
    {
        return spriteRenderer.color;
    }

    public override void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}