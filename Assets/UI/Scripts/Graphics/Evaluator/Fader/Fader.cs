using UnityEngine;

public abstract class Fader : Evaluator<float>
{
    [SerializeField] protected AnimationCurve fadeCurve;

    public override float Evaluate(float state)
    { return fadeCurve.Evaluate(state); }
}