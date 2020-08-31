using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GradientorSpriteRenderer : Gradientor
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        this.ValidateComponent(ref spriteRenderer);
    }

    public override Color GetValue()
    {
        return spriteRenderer.color;
    }

    public override void SetValue(Color amount)
    {
        spriteRenderer.color = amount;
    }
}
