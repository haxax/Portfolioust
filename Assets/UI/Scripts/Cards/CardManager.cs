using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO , Doesn't do much atm

public class CardManager : Singleton<CardManager>
{
    [SerializeField] private RectTransform cardPanel;

    public RectTransform CardPanel { get => cardPanel; private set => cardPanel = value; }

    private void OnValidate()
    {
        this.ValidateComponentInScene(ref cardPanel, "CardPanel");
    }
}