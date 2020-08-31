using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FaderSpriteRenderer : Fader
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        this.ValidateComponent(ref spriteRenderer);
    }

    public override float GetValue()
    {
        return spriteRenderer.color.a;
    }

    public override void SetValue(float amount)
    {
        spriteRenderer.color = spriteRenderer.color.ChangeAlpha(amount);
    }
}
