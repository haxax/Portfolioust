using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FaderCanvasGroup : Fader
{
    [SerializeField] private CanvasGroup canvasGroup;

    private void OnValidate()
    {
        this.ValidateComponent(ref canvasGroup);
    }

    public override float GetValue()
    {
        return canvasGroup.alpha;
    }

    public override void SetValue(float amount)
    {
        canvasGroup.alpha = amount;
    }
}
