using UnityEngine;

public abstract class Gradientor : Evaluator<Color>
{
    [SerializeField] protected Gradient gradientCurve;

    public override Color Evaluate(float state)
    { return gradientCurve.Evaluate(state); }
}