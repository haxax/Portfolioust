using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class InfoCardUI : CardUI
{
    [HideInInspector] [SerializeField] private InfoCard infoCard;
    public InfoCard InfoCard { get => infoCard; private set => infoCard = value; }

    protected virtual void OnValidate()
    {
        gameObject.ValidateComponent(ref infoCard);
    }

    public override void UpdateContent()
    {
    }

    public override Card Card()
    { return InfoCard; }
}