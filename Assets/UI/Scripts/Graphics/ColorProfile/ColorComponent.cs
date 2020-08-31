using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorComponent : MonoBehaviour
{
    [SerializeField] private ColorTarget colorType = ColorTarget.none;

    public ColorTarget ColorType { get => colorType; private set => colorType = value; }

    protected virtual void OnEnable()
    {
        ColorProfileManager.Instance.AddColorComponent(this);
        SetColor(ColorProfileManager.Instance.ActiveProfile.GetColor(ColorType));
    }

    protected virtual void OnDisable()
    {
        ColorProfileManager.Instance.RemoveColorComponent(this);
    }

    public abstract void SetColor(Color color);
    public abstract Color GetColor();
}
