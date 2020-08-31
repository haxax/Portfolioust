using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[RequireComponent(typeof(DeckUI))]
public class Deck : MonoBehaviour
{
    [HideInInspector] [SerializeField] private DeckUI deckUI;

    /// <summary>
    /// List of loaded cards
    /// </summary>
    public List<Card> Cards { get; private set; } = new List<Card>();
    public DefaultDeckSO DeckData { get; private set; }

    public int DeckID { get; private set; } = -1;
    public DeckUI DeckUI { get => deckUI; private set => deckUI = value; }

    private void OnValidate()
    {
        this.ValidateComponent(ref deckUI);
    }

    public void Setup(DefaultDeckSO _deckData, int deckID)
    {
        DeckID = deckID;
        DeckData = _deckData;
        LoadDeck();
    }

    /// <summary>
    /// Load and create cards to the deck
    /// </summary>
    private void LoadDeck()
    {
        // Create offline cards
        SetCards(DeckData.GetPresetCards(), false);

        // Load and create online cards. If online, overrides offline cards.
        StartCoroutine(DeckData.OnlineDeck.LoadDeck(SetCards));
    }

    /// <summary>
    /// Destroy loaded cards
    /// </summary>
    private void DiscardDeck()
    {
        for (int i = 0; i < Cards.Count; i++)
        { Cards[i].Discard(); }
        Cards.Clear();
    }

    /// <summary>
    /// Creates and adds given cards to the deck
    /// </summary>
    /// <param name="_cards">Data of the cards to be created</param>
    /// <param name="overrideExistingCards">If true, destroy existing cards</param>
    public void SetCards(List<CardData> _cards, bool overrideExistingCards)
    {
        if (_cards.Count == 0)
        { Debug.Log("Returning empty card stack @ " + gameObject.name); return; }

        if (overrideExistingCards)
        { DiscardDeck(); }

        for (int i = 0; i < _cards.Count; i++)
        { CreateNewCard(_cards[i]); }

        DeckUI.UpdateUI();
    }

    /// <summary>
    /// Creates and adds card to the deck based on the data
    /// </summary>
    /// <param name="cardData">Data of the new card</param>
    private void CreateNewCard(CardData cardData)
    {
        Card newCard = Instantiate(CardPrefabStorage.Instance.FindCardPrefabOfType(cardData.GetCardDataType()), CardManager.Instance.CardPanel);
        newCard.SetupCard(cardData);
        Cards.Add(newCard);
    }

    public void DestroyDeck()
    {
        DiscardDeck();
        Destroy(gameObject);
    }
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
    /// Loads card datas from the given Google Sheets. Returns the cards and boolean whether override preset cards.
    /// </summary>
    /// <param name="resultAction">Action invoked at the end of loading. Sends card data to that action to be handled.</param>
    /// <returns>Returns after web requests are handled</returns>
    public IEnumerator LoadDeck(UnityAction<List<CardData>, bool> resultAction)
    {
        List<CardData> result = new List<CardData>();
        if (!IsInUse()) { yield break; }

        using (UnityWebRequest request = UnityWebRequest.Get(GetUrl()))
        {
            // Load and split Google sheet into arrays
            yield return request.SendWebRequest();
            string requestResult = request.downloadHandler.text;
            string[] lines = requestResult.Split(new string[] { "\n", "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
            string[][] sheet = lines.Select(s => s.Split("\t".ToCharArray())).ToArray().ToArray();

            // Create card datas based on loaded sheet
            // Ignore first and empty rows
            for (int i = 1; i < sheet.Length; i++)
            {
                if (sheet[i][0] == "") { continue; }
                result.Add(CardData.CreateCard(sheet[i]));
            }
        }
        // Send card datas to be handled
        resultAction.Invoke(result, OverrideDefaultDeck);
    }
}