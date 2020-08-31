using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Card", order = 20)]
public class DefaultCardSO : ScriptableObject
{
    [Tooltip("0 = CardType \n1 = Title \n2 = Desc \nCheck CardType for more.")]
    [SerializeField] private List<string> data = new List<string>();

    public string[] RawData => data.ToArray();
    public CardData CardData => CardData.CreateCard(RawData);
}