using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScroller : Scroller1D
{
    public float Width { get; set; } = 1500f;
    public float Position { get; private set; } = 750f;
    public void AddPosition(float amount)
    {
        Position = Mathf.Repeat(Position + amount, Width);
    }

    protected override void OnUpdate(float change)
    {
        AddPosition(change);
        GetComponent<RectMover>().UpdatePosition(Position, Width);
    }
}
