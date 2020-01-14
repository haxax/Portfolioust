using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class ProjectCardUI : CardUI
{
    [HideInInspector] [SerializeField] private ProjectCard projectCard;
    public ProjectCard ProjectCard { get => projectCard; private set => projectCard = value; }

    protected virtual void OnValidate()
    {
        gameObject.ValidateComponent(ref projectCard);
    }

    public override void UpdateContent()
    {
    }

    public override Card Card()
    { return ProjectCard; }
}