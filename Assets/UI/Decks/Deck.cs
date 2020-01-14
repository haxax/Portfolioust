using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;


public class Deck : MonoBehaviour
{
    public List<Card> Cards { get; private set; } = new List<Card>();
    public DefaultDeckSO DeckData { get; private set; }

    public void Setup(DefaultDeckSO _deckData)
    {
        DeckData = _deckData;
        LoadDeck();
    }

    private void LoadDeck()
    {
        SetCards(DeckData.GetPresetCards(), false);
        DeckData.OnlineDeck.LoadDeck(SetCards);
    }

    private void DiscardDeck()
    {
        for (int i = 0; i < Cards.Count; i++)
        { Cards[i].Discard(); }
        Cards.Clear();
    }

    public void SetCards(List<CardData> _cards, bool overrideExistingCards)
    {
        if (overrideExistingCards)
        { DiscardDeck(); }

        for (int i = 0; i < _cards.Count; i++)
        { CreateNewCard(_cards[i]); }
    }

    private void CreateNewCard(CardData cardData)
    {
        Card newCard = Instantiate(CardPrefabStorage.Instance.FindCardOfType(cardData.CardType), transform);

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

[System.Serializable]
public class OnlineDeckData
{
    [Tooltip("If set to true, preset cards are ignored and only online cards used.")]
    [SerializeField] private bool overrideDefaultDeck = true;
    [Tooltip("Google Sheets ID")]
    [SerializeField] private string sheetId = "";
    [Tooltip("Google Sheets page number")]
    [SerializeField] private string pageId = "0";

    public bool OverrideDefaultDeck => overrideDefaultDeck;

    public bool IsInUse()
    {
        if (sheetId == "") { return false; }
        return true;
    }

    /// <summary>
    /// Return Google Sheet url for the deck including the page number.
    /// </summary>
    public string GetUrl()
    { return "https://docs.google.com/spreadsheets/d/" + sheetId + "/export?format=tsv&gid=" + pageId; }

    /// <summary>
    /// Loads cards from the given Google Sheets to the deck. Returns the cards and boolean whether override preset cards.
    /// </summary>
    public IEnumerator LoadDeck(UnityAction<List<CardData>, bool> resultAction)
    {
        List<CardData> result = new List<CardData>();
        if (!IsInUse()) { yield break; }

        using (UnityWebRequest request = new UnityWebRequest(GetUrl()))
        {
            yield return request;
            string requestResult = request.downloadHandler.text;

            string[] lines = requestResult.Split(new string[] { "\n", "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            string[][] sheet = lines.Select(s => s.Split("\t".ToCharArray())).ToArray().ToArray();

            for (int i = 1; i < sheet.Length; i++)
            {
                if (sheet[i][0] == "") { continue; }
                result.Add(CardData.CreateCard(sheet[i]));
            }
        }
        resultAction.Invoke(result, OverrideDefaultDeck);
    }
}