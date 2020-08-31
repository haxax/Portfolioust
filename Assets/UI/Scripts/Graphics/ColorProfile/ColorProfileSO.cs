using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorProfile", menuName = "UI/ColorProfile", order = 700)]
public class ColorProfileSO : ScriptableObject
{
    [SerializeField] private Color none;
    [Space(10)]
    [SerializeField] private Color background;
    [Space(10)]
    [SerializeField] private Color cardA;
    [SerializeField] private Color cardB;
    [Space(10)]
    [SerializeField] private Color titleMain;
    [SerializeField] private Color titleA;
    [SerializeField] private Color titleB;
    [Space(10)]
    [SerializeField] private Color textA;
    [SerializeField] private Color textB;

    public Color None { get => none; }
    public Color Background { get => background; }
    public Color CardA { get => cardA; }
    public Color CardB { get => cardB; }
    public Color TitleMain { get => titleMain; }
    public Color TitleA { get => titleA; }
    public Color TitleB { get => titleB; }
    public Color TextA { get => textA; }
    public Color TextB { get => textB; }

    public Color GetColor(ColorTarget colorType)
    {
        switch (colorType)
        {
            case ColorTarget.none:
                return None;
            case ColorTarget.background:
                return Background;
            case ColorTarget.cardA:
                return CardA;
            case ColorTarget.cardB:
                return CardB;
            case ColorTarget.titleMain:
                return TitleMain;
            case ColorTarget.titleA:
                return TitleA;
            case ColorTarget.titleB:
                return TitleB;
            case ColorTarget.textA:
                return TextA;
            case ColorTarget.textB:
                return TextB;
        }
        return None;
    }
}

public enum ColorTarget
{
    none = 0,
    background = 10,
    cardA = 50,
    cardB = 51,
    titleMain = 100,
    titleA = 101,
    titleB = 102,
    textA = 150,
    textB = 151,
}