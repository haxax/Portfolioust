using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : Singleton<DeckManager>
{
    [Tooltip("If true, loads decks on start")]
    [SerializeField] private bool isOn = true;
    [SerializeField] private RectTransform deckPanel;

    [Tooltip("Static scriptableobjects which must exist")]
    [SerializeField] private List<ScriptableObject> tempGlobalScriptableObjectList = new List<ScriptableObject>();

    private Deck activeDeck = null;
    public Deck ActiveDeck { get; private set; }

    /// <summary>
    /// Loaded decks
    /// </summary>
    public List<Deck> Decks { get; private set; } = new List<Deck>();

    private void OnValidate()
    {
        this.ValidateComponentInScene(ref deckPanel, "DeckPanel");
    }

    /// <summary>
    /// Deck loading starts here
    /// </summary>
    protected override void Awake()
    {
        TemporaryUntilSingletonSOFixed();
        base.Awake();
        LoadDefaultDecks();
    }

    private void TemporaryUntilSingletonSOFixed()
    {
        foreach (ScriptableObject temp in tempGlobalScriptableObjectList)
        {
            Instantiate(temp);
        }
        if (DeckCollectionStorage.Instance) { }
        if (UISettingsSO.Instance) { }
        if (CardPrefabStorage.Instance) { }
    }

    private void LoadDefaultDecks()
    {
        if (!isOn) { return; }
        ClearDecks();

        for (int i = 0; i < DeckCollectionStorage.Instance.Decks.Count; i++)
        {
            Deck newDeck = Instantiate(DeckCollectionStorage.Instance.DeckPrefab, deckPanel);
            newDeck.gameObject.name = "Deck_" + DeckCollectionStorage.Instance.Decks[i].name;
            newDeck.Setup(DeckCollectionStorage.Instance.Decks[i], i);
            Decks.Add(newDeck);
        }

        ActiveDeck = Decks[0];
    }

    /// <summary>
    /// Destroys existing decks and their cards
    /// </summary>
    private void ClearDecks()
    {
        for (int i = Decks.Count - 1; i >= 0; i--)
        {
            Decks[i].DestroyDeck();
        }
        Decks = new List<Deck>();
    }

    public void OpenDeck(Deck deck)
    {
        if (activeDeck != null && activeDeck != deck) { activeDeck.DeckUI.CloseDeck(); }
        activeDeck = deck;
    }
}