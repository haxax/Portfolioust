using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardUI : MonoBehaviour
{
    public abstract Card Card();

    public abstract void UpdateContent();
}