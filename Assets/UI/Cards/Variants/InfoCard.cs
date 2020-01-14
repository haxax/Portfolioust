using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InfoCardUI))]
public class InfoCard : Card
{
    [HideInInspector] [SerializeField] private InfoCardUI infoCardUI;
    public InfoCardUI InfoCardUI { get => infoCardUI; private set => infoCardUI = value; }

    protected virtual void OnValidate()
    {
        gameObject.ValidateComponent(ref infoCardUI);
    }

    public InfoCardData Data { get; private set; }

    public override Type GetCardType()
    { return typeof(InfoCard); }

    public override CardData GetData()
    { return Data; }

    public override void SetData(CardData cardData)
    { Data = cardData as InfoCardData; }

    public override CardUI CardUI()
    { return InfoCardUI; }
}