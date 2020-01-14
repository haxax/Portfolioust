using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ErrorCardUI))]
public class ErrorCard : Card
{
    [HideInInspector] [SerializeField] private ErrorCardUI errorCardUI;
    public ErrorCardUI ErrorCardUI { get => errorCardUI; private set => errorCardUI = value; }

    protected virtual void OnValidate()
    {
        gameObject.ValidateComponent(ref errorCardUI);
    }

    public ErrorCardData Data { get; private set; }

    public override Type GetCardType()
    { return typeof(ErrorCard); }

    public override CardData GetData()
    { return Data; }

    public override void SetData(CardData cardData)
    { Data = cardData as ErrorCardData; }

    public override CardUI CardUI()
    { return ErrorCardUI; }
}