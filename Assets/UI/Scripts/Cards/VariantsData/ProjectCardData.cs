using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectCardData : CardData
{
    [SerializeField] private string title = "";
    [SerializeField] private string desc = "";
    [SerializeField] private string date = "";
    [SerializeField] private string platform = "";
    [SerializeField] private string team = "1";
    [SerializeField] private string link = "";
    [SerializeField] private string video = "private";
    [SerializeField] private string videoId = "";
    [SerializeField] private string tier = "0";

    public string Title { get => title; private set => title = value; }
    public string Desc { get => desc; private set => desc = value; }
    public string Date { get => date; private set => date = value; }
    public string Platform { get => platform; private set => platform = value; }
    public string Team { get => team; private set => team = value; }
    public string Link { get => link; private set => link = value; }
    public string Video { get => video; private set => video = value; }
    public string VideoId { get => videoId; private set => videoId = value; }
    public string Tier { get => tier; private set => tier = value; }

    public ProjectCardData(string[] data)
    {
        data.SafeSet(1, ref title);
        data.SafeSet(2, ref desc);
        data.SafeSet(3, ref date);
        data.SafeSet(4, ref platform);
        data.SafeSet(5, ref tier);
        data.SafeSet(6, ref team);
        data.SafeSet(7, ref link);
        data.SafeSet(8, ref videoId);
        data.SafeSet(9, ref video);
    }


    public override int DataCount()
    { return 9; }

    public override Type GetCardDataType()
    { return typeof(ProjectCardData); }

    public override string GetCardName()
    { return Title; }
}