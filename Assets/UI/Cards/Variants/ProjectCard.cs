using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectCardUI))]
public class ProjectCard : Card
{
    [HideInInspector] [SerializeField] private ProjectCardUI projectCardUI;
    public ProjectCardUI ProjectCardUI { get => projectCardUI; private set => projectCardUI = value; }

    protected virtual void OnValidate()
    {
        gameObject.ValidateComponent(ref projectCardUI);
    }

    public ProjectCardData Data { get; private set; }

    public override Type GetCardType()
    { return typeof(ProjectCard); }

    public override CardData GetData()
    { return Data; }

    public override void SetData(CardData cardData)
    { Data = cardData as ProjectCardData; }

    public override CardUI CardUI()
    { return ProjectCardUI; }

    public override bool CountInCardTotal => true;
}