using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scroller : MonoBehaviour
{
    public abstract void AddForce(float amount, ScrollDirection direction);
    public abstract void Stop();
}


public enum ScrollDirection
{
    any = 0,
    vertical = 1,
    horizontal = 2,
}