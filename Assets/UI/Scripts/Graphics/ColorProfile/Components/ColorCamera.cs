using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ColorCamera : ColorComponent
{
    [HideInInspector] [SerializeField] private new Camera camera;

    private void OnValidate()
    {
        this.ValidateComponent(ref camera);
    }

    public override Color GetColor()
    {
        return camera.backgroundColor;
    }

    public override void SetColor(Color color)
    {
        camera.backgroundColor = color;
    }
}