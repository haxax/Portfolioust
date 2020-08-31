using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeltaChange
{
    [Tooltip("Should be negative value")]
    [SerializeField] private float deceleration = -1f;
    public float Deceleration { get => deceleration; private set => deceleration = value; }

    public float Velocity { get; private set; } = 0.0f;

    public float Direction { get => Velocity / Mathf.Abs(Velocity); }

    public void AddVelocity(float amount) => Velocity += amount;
    public void Stop() => Velocity = 0f;

    /// <summary>
    /// Updates the velocity
    /// </summary>
    /// <param name="deltaTime">Input Time.DeltaTime</param>
    /// <returns>Returns moved distance.</returns>
    public float Update(float deltaTime)
    {
        if (Velocity == 0) { return 0f; }

        float previousDirection = Direction;
        float distance = (Velocity * deltaTime) + (0.5f * Deceleration * previousDirection * Mathf.Pow(deltaTime, 2));

        Velocity = Velocity + (Deceleration * deltaTime * previousDirection);
        float currentDirection = Direction;
        if (currentDirection * previousDirection < 0)
        { Velocity = 0f; }

        return distance;
    }
}
