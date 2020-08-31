using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GradientorImage : Gradientor
{
    [SerializeField] private Image image;

    private void OnValidate()
    {
        this.ValidateComponent(ref image);
    }

    public override Color GetValue()
    {
        return image.color;
    }

    public override void SetValue(Color amount)
    {
        image.color = amount;
    }
}
