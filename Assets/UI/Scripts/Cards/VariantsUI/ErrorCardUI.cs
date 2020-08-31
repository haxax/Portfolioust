using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("")]
public class ErrorCardUI : CardUI
{
    [HideInInspector] [SerializeField] private ErrorCard errorCard;
    public ErrorCard ErrorCard { get => errorCard; private set => errorCard = value; }

    [SerializeField] private Text titleTxt;
    [SerializeField] private Text descTxt;

    protected virtual void OnValidate()
    {
        this.ValidateComponent(ref errorCard);
        this.ValidateComponentInChildren(ref titleTxt, "TitleTxt");
        this.ValidateComponentInChildren(ref descTxt, "DescTxt");
    }

    public override void UpdateContent()
    {
        base.UpdateContent();
        titleTxt.text = ErrorCard.Data.Title;
        descTxt.text = ErrorCard.Data.Desc;
    }

    public override Card Card()
    { return ErrorCard; }
}