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

    public virtual bool CountInCardTotal => false;


    public void Discard()
    {
        OnDiscard();
        Destroy(gameObject);
    }

    protected virtual void OnDiscard() { }
}