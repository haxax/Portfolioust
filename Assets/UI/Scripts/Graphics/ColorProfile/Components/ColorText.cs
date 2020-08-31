using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ColorText : ColorComponent
{
    [HideInInspector] [SerializeField] private Text text;

    private void OnValidate()
    {
        this.ValidateComponent(ref text);
    }

    public override Color GetColor()
    {
        return text.color;
    }

    public override void SetColor(Color color)
    {
        text.color = color;
    }
}