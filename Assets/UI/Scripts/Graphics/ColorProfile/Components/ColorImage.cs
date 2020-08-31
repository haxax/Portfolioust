using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorImage : ColorComponent
{
    [HideInInspector] [SerializeField] private Image image;

    private void OnValidate()
    {
        this.ValidateComponent(ref image);
    }

    public override Color GetColor()
    {
        return image.color;
    }

    public override void SetColor(Color color)
    {
        image.color = color;
    }
}