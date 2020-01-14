﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649

[CreateAssetMenu(fileName = "NewDeck", menuName = "Cards/Deck", order = 0)]
public class DefaultDeckSO : ScriptableObject
{
    [SerializeField] private DeckData deck;
    [Space(20)]
    [SerializeField] private List<DefaultCardSO> cards = new List<DefaultCardSO>();
    [Space(20)]
    [SerializeField] private OnlineDeckData onlineDeck;

    public DeckData Deck => deck;
    public List<DefaultCardSO> Cards => cards;
    public OnlineDeckData OnlineDeck => onlineDeck;

    public List<CardData> GetPresetCards()
    {
        List<CardData> result = new List<CardData>();

        for (int i = 0; i < cards.Count; i++)
        { result.Add(cards[i].CardData); }

        return result;
    }
}
