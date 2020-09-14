using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardUI : MonoBehaviour
{
    public abstract Card Card();

    public virtual void UpdateContent()
    {
        UpdateGameObjectName();
    }

    public void UpdateGameObjectName()
    { gameObject.name = Card().GetCardType() + "_" + Card().GetData().GetCardName(); }

    public virtual void EnableCard(bool state)
    {
        gameObject.SetActive(state);
    }
}