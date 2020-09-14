using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public abstract CardUI CardUI();

    public abstract CardData GetData();
    public abstract void SetData(CardData cardData);

    public abstract Type GetCardType();

    /// <summary>
    /// Count only cards which represents a project and ignore info cards
    /// </summary>
    public virtual bool CountInCardTotal => false;

    public void SetupCard(CardData cardData)
    {
        SetData(cardData);
        CardUI().UpdateContent();
    }

    public void Discard()
    {
        OnDiscard();
        Destroy(gameObject);
    }

    protected virtual void OnDiscard() { }

}