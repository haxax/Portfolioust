using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649

[CreateAssetMenu(fileName = "DeckCollection", menuName = "Storages/DeckCollection", order = 40)]
public class DeckCollectionStorage : SingletonSO<DeckCollectionStorage>
{
    [Header("Create to Resources folder. Avoid Duplicates.")]

    [Tooltip("Default prefab for a deck")]
    [SerializeField] private Deck deckPrefab;

    [Tooltip("List of active decks used within the project")]
    [SerializeField] private List<DefaultDeckSO> decks = new List<DefaultDeckSO>();

    public Deck DeckPrefab => deckPrefab;
    public List<DefaultDeckSO> Decks => decks;
}