using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scroller2D : Scroller
{
    [SerializeField] protected DeltaChange forceVertical;
    [SerializeField] protected DeltaChange forceHorizontal;

    public override void AddForce(float amount, ScrollDirection inputDirection)
    {
        if (inputDirection == ScrollDirection.vertical || inputDirection == ScrollDirection.any)
        { forceVertical.AddVelocity(amount); }

        if (inputDirection == ScrollDirection.horizontal || inputDirection == ScrollDirection.any)
        { forceHorizontal.AddVelocity(amount); }

        this.enabled = true;
    }

    public override void Stop()
    {
        forceVertical.Stop();
        forceHorizontal.Stop();
        this.enabled = false;
    }

    private void Update()
    {
        OnUpdate(new Vector2(
            forceHorizontal.Update(Time.deltaTime),
            forceVertical.Update(Time.deltaTime)));

        if (forceHorizontal.Velocity == 0.0f && forceVertical.Velocity == 0.0f)
        { Stop(); }
    }

    protected abstract void OnUpdate(Vector2 change);
}