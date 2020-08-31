using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCardData : CardData
{
    [SerializeField] private string title = "";
    [SerializeField] private string desc = "";

    public string Title { get => title; private set => title = value; }
    public string Desc { get => desc; private set => desc = value; }


    public InfoCardData(string[] data)
    {
        data.SafeSet(1, ref title);
        data.SafeSet(2, ref desc);
    }


    public override int DataCount()
    { return 2; }

    public override Type GetCardDataType()
    { return typeof(InfoCardData); }

    public override string GetCardName()
    { return Title; }
}