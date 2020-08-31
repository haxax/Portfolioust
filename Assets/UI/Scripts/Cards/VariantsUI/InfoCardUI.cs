using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("")]
public class InfoCardUI : CardUI
{
    [HideInInspector] [SerializeField] private InfoCard infoCard;
    public InfoCard InfoCard { get => infoCard; private set => infoCard = value; }

    [SerializeField] private Text titleTxt;
    [SerializeField] private Text descTxt;

    protected virtual void OnValidate()
    {
        this.ValidateComponent(ref infoCard);
        this.ValidateComponentInChildren(ref titleTxt, "TitleTxt");
        this.ValidateComponentInChildren(ref descTxt, "DescTxt");
    }

    public override void UpdateContent()
    {
        base.UpdateContent();
        titleTxt.text = InfoCard.Data.Title;
        descTxt.text = InfoCard.Data.Desc;
    }

    public override Card Card()
    { return InfoCard; }
}