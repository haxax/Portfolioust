using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProfileManager : Singleton<ColorProfileManager>
{
    [SerializeField] private ColorProfileSO activeProfile;

    public List<ColorComponent> ComponentsNone { get; private set; } = new List<ColorComponent>();
    public List<ColorComponent> ComponentsBackground { get; private set; } = new List<ColorComponent>();
    public List<ColorComponent> ComponentsCardA { get; private set; } = new List<ColorComponent>();
    public List<ColorComponent> ComponentsCardB { get; private set; } = new List<ColorComponent>();
    public List<ColorComponent> ComponentsTitleMain { get; private set; } = new List<ColorComponent>();
    public List<ColorComponent> ComponentsTitleA { get; private set; } = new List<ColorComponent>();
    public List<ColorComponent> ComponentsTitleB { get; private set; } = new List<ColorComponent>();
    public List<ColorComponent> ComponentsTextA { get; private set; } = new List<ColorComponent>();
    public List<ColorComponent> ComponentsTextB { get; private set; } = new List<ColorComponent>();

    public ColorProfileSO ActiveProfile
    {
        get => activeProfile;
        set
        {
            if (activeProfile == value) { return; }
            activeProfile = value;
            UpdateProfile();
        }
    }

    public void AddColorComponent(ColorComponent component)
    { GetColorComponentList(component.ColorType).Add(component); }

    public void RemoveColorComponent(ColorComponent component)
    { GetColorComponentList(component.ColorType).Remove(component); }

    public List<ColorComponent> GetColorComponentList(ColorTarget colorType)
    {
        switch (colorType)
        {
            case ColorTarget.none:
                return ComponentsNone;
            case ColorTarget.background:
                return ComponentsBackground;
            case ColorTarget.cardA:
                return ComponentsCardA;
            case ColorTarget.cardB:
                return ComponentsCardB;
            case ColorTarget.titleMain:
                return ComponentsTitleMain;
            case ColorTarget.titleA:
                return ComponentsTitleA;
            case ColorTarget.titleB:
                return ComponentsTitleB;
            case ColorTarget.textA:
                return ComponentsTextA;
            case ColorTarget.textB:
                return ComponentsTextB;
        }
        return null;
    }


    public void UpdateProfile()
    {
        UpdateListColor(ComponentsNone, ActiveProfile.None);
        UpdateListColor(ComponentsBackground, ActiveProfile.Background);
        UpdateListColor(ComponentsCardA, ActiveProfile.CardA);
        UpdateListColor(ComponentsCardB, ActiveProfile.CardB);
        UpdateListColor(ComponentsTitleMain, ActiveProfile.TitleMain);
        UpdateListColor(ComponentsTitleA, ActiveProfile.TitleA);
        UpdateListColor(ComponentsTitleB, ActiveProfile.TitleB);
        UpdateListColor(ComponentsTextA, ActiveProfile.TextA);
        UpdateListColor(ComponentsTextB, ActiveProfile.TextB);
    }
    private void UpdateListColor(List<ColorComponent> components, Color color)
    {
        for (int i = 0; i < components.Count; i++)
        { components[i].SetColor(color); }
    }
}