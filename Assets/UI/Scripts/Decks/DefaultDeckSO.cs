using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649

[CreateAssetMenu(fileName = "NewDeck", menuName = "Cards/Deck", order = 0)]
public class DefaultDeckSO : ScriptableObject
{
    [SerializeField] private DeckData deck;
    [Space(20)]

    [Tooltip("These cards are loaded if user is offline")]
    [SerializeField] private List<DefaultCardSO> cards = new List<DefaultCardSO>();
    [Space(20)]

    [Tooltip("Google sheets address to load cards if user is online")]
    [SerializeField] private OnlineDeckData onlineDeck;

    public DeckData Deck => deck;
    public List<DefaultCardSO> Cards => cards;
    public OnlineDeckData OnlineDeck => onlineDeck;

    /// <summary>
    /// Get default card datas for offline use
    /// </summary>
    /// <returns>List of card datas which should be used only if user is offline</returns>
    public List<CardData> GetPresetCards()
    {
        List<CardData> result = new List<CardData>();

        for (int i = 0; i < cards.Count; i++)
        { result.Add(cards[i].CardData); }

        return result;
    }
}


[System.Serializable]
public class DeckData
{
    [SerializeField] private string deckName;
    public string DeckName { get => deckName; private set => deckName = value; }

    [SerializeField] private bool preload = true;
    public bool Preload { get => preload; private set => preload = value; }
}