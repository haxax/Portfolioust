using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckCollection", menuName = "Storages/DeckCollection", order = 40)]
public class DeckCollectionStorage : SingletonSO<DeckCollectionStorage>
{
    [Header("Create to Resources folder. Avoid Duplicates.")]
    [SerializeField] private List<DefaultDeckSO> decks = new List<DefaultDeckSO>();
    public List<DefaultDeckSO> Decks => decks;
}