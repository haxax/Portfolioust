using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardPrefabs", menuName = "Storages/CardPrefabs", order = 50)]
public class CardPrefabStorage : SingletonSO<CardPrefabStorage>
{
    [Header("Create to Resources folder. Avoid Duplicates.")]
    [SerializeField] private List<Card> cards = new List<Card>();
    public List<Card> Cards => cards;

    public Card FindCardOfType(Type cardType)
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i].GetCardType() == cardType)
            { return Cards[i]; }
        }
        return null;
    }
}