using UnityEngine;

public abstract class Evaluator<T> : MonoBehaviour
{
    /// <summary>
    /// Sets the evaluated value on timeline.
    /// </summary>
    /// <param name="state">Value between 0-1.</param>
    public void UpdateState(float state)
    { SetValue(Evaluate(state)); }

    public abstract T Evaluate(float state);
    public abstract T GetValue();
    public abstract void SetValue(T amount);
}