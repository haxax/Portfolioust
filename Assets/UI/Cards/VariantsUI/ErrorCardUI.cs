using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class ErrorCardUI : CardUI
{
    [HideInInspector] [SerializeField] private ErrorCard errorCard;
    public ErrorCard ErrorCard { get => errorCard; private set => errorCard = value; }

    protected virtual void OnValidate()
    {
        gameObject.ValidateComponent(ref errorCard);
    }

    public override void UpdateContent()
    {
    }

    public override Card Card()
    { return ErrorCard; }
}