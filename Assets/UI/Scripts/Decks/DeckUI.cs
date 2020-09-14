using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("")] //Automatically added by Deck -component
public class DeckUI : MonoBehaviour
{
    [HideInInspector] [SerializeField] private Deck deck;
    [HideInInspector] [SerializeField] private RectTransform rectBody;
    [SerializeField] private Text titleTxt;

    public Deck Deck { get => deck; private set => deck = value; }
    public RectTransform RectBody { get => rectBody; private set => rectBody = value; }

    private int countedCards = 0;

    private void OnValidate()
    {
        this.ValidateComponent(ref rectBody);
        this.ValidateComponent(ref deck);
        this.ValidateComponentInChildren(ref titleTxt, "TitleTxt");
    }

    public void UpdateUI()
    {
        CountCards();
        UpdateName();
        ResetPosition();
    }


    private void CountCards()
    {
        countedCards = 0;
        foreach (Card card in Deck.Cards)
        {
            if (card.CountInCardTotal)
            { countedCards++; }
        }
    }

    private void UpdateName()
    {
        titleTxt.text = Deck.DeckData.Deck.DeckName;
        if (countedCards > 0)
        { titleTxt.text += $" [{countedCards}]"; }
    }

    /// <summary>
    /// Sets the UI position based on the amount of other decks
    /// </summary>
    private void ResetPosition()
    {
        float yPos = -RectBody.sizeDelta.y / 2;

        for (int i = 0; i < DeckManager.Instance.Decks.Count; i++)
        {
            if (DeckManager.Instance.Decks[i] == Deck) { break; }
            yPos -= DeckManager.Instance.Decks[i].DeckUI.RectBody.sizeDelta.y;
        }

        RectBody.anchoredPosition = RectBody.anchoredPosition.ChangeY(yPos);
    }

    public void OpenDeck()
    {
        DeckManager.Instance.OpenDeck(this.Deck);
        EnableCards(true);
    }

    public void CloseDeck()
    {
        EnableCards(false);
    }

    private void EnableCards(bool state)
    {
        for (int i = 0; i < Deck.Cards.Count; i++)
        {
            Deck.Cards[i].CardUI().EnableCard(state);
        }
    }
}
