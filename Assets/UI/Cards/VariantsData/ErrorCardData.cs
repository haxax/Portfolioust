using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCardData : CardData
{
    [SerializeField] private string title = "Error occured!";
    [SerializeField] private string desc = "Missing error msg!";

    public string Title { get => title; private set => title = value; }
    public string Desc { get => desc; private set => desc = value; }



    /// <summary>
    /// Create card for errors.
    /// </summary>
    /// <param name="data"> 0=Desc</param>
    public ErrorCardData(string[] data)
    {
        data.SafeSet(1, ref desc);
    }

    /// <summary>
    /// Create card for errors.
    /// </summary>
    public ErrorCardData(string errorMsg) : this(new string[] { "ErrorCardData", errorMsg }) { }



    public override int DataCount()
    { return 1; }

    public override Type GetCardDataType()
    { return typeof(ErrorCardData); }
}