using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardData
{
    public static CardData CreateCard(string[] data)
    {
        CardData newCard;
        Type cardType;

        try
        {
            cardType = Type.GetType(data[0] + "Data");
            System.Object obj = Activator.CreateInstance(cardType, new object[] { data });
            newCard = obj as CardData;
        }
        catch
        {
            Debug.LogWarning("Card creation failed, invalid type?");
            cardType = typeof(ErrorCard);
            newCard = new ErrorCardData("Card creation failed, invalid type?") as CardData;
        }
        
        return newCard;
    }

    /// <summary>
    /// Validate if input data can be used to create the card.
    /// </summary>
    /// <param name="inputDataCount">Count of the raw incoming string[] data. Including [0] type.</param>
    /// <returns>Returns true if inputDataCount equals or is greater than DataCount()+1.</returns>
    public bool DataCountMatch(int inputDataCount)
    {
        // +1 to include [0] type
        if (inputDataCount < DataCount() + 1) { return false; }
        return true;
    }

    /// <summary>
    /// Should return the count of data slots defined in the subclass. Doesn't count input[0] type.
    /// </summary>
    public abstract int DataCount();

    public abstract Type GetCardDataType();

    public abstract string GetCardName();
}