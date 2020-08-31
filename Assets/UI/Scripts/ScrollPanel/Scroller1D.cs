using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scroller1D : Scroller
{
    [SerializeField] protected DeltaChange force;
    [SerializeField] protected ScrollDirection scrollDirection = ScrollDirection.any;

    public override void AddForce(float amount, ScrollDirection inputDirection)
    {
        if (scrollDirection == ScrollDirection.horizontal && inputDirection == ScrollDirection.vertical) { return; }
        else if (scrollDirection == ScrollDirection.vertical && inputDirection == ScrollDirection.horizontal) { return; }

        force.AddVelocity(amount);
        this.enabled = true;
    }

    public override void Stop()
    {
        force.Stop();
        this.enabled = false;
    }

    private void Update()
    {
        OnUpdate(force.Update(Time.deltaTime));
        if (force.Velocity == 0.0f)
        { Stop(); }
    }

    protected abstract void OnUpdate(float change);
}