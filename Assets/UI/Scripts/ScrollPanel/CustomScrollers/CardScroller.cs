using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScroller : Scroller1D
{
    public float Height { get; set; } = 1500f;
    public float Position { get; private set; } = 750f;
    public void AddPosition(float amount)
    {
        Position = Mathf.Clamp(Position + amount, 0.0f, Height);
    }

    protected override void OnUpdate(float change)
    {
        AddPosition(change);
        GetComponent<RectMover>().UpdatePosition(Position, Height);
    }
}
