using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardPrefabs", menuName = "Storages/CardPrefabs", order = 50)]
public class CardPrefabStorage : SingletonSO<CardPrefabStorage>
{
    [Header("Create to Resources -folder. Avoid Duplicates.")]

    [Tooltip("List of different type of card prefabs")]
    [SerializeField] private List<Card> cards = new List<Card>();
    public List<Card> Cards => cards;

    /// <summary>
    /// Returns valid prefab for the type of card
    /// </summary>
    /// <param name="cardType">Type of the</param>
    /// <returns>Default prefab of the card type</returns>
    public Card FindCardPrefabOfType(Type cardType)
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i].GetData().GetCardDataType() == cardType)
            { return Cards[i]; }
        }
        return null;
    }
}