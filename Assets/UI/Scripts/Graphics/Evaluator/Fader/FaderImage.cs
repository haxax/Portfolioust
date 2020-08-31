using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FaderImage : Fader
{
    [SerializeField] private Image image;

    private void OnValidate()
    {
        this.ValidateComponent(ref image);
    }

    public override float GetValue()
    {
        return image.color.a;
    }

    public override void SetValue(float amount)
    {
        image.color = image.color.ChangeAlpha(amount);
    }
}
