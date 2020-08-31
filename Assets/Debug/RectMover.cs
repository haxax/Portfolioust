using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve cap = new AnimationCurve();
    [SerializeField] private float speed = 1f;
    [SerializeField] private RectTransform rect;

    private float timer = 0;
    private float dir = 1;
    private float offset = 0;

    private void OnValidate()
    {
        this.ValidateComponent(ref rect);
    }

    private void Awake()
    {
        offset = rect.localPosition.y;
    }

    void Update()
    {
        timer += Time.deltaTime * speed * dir;

        if (dir > 0 && timer >= 1f)
        {
            dir *= -1;
        }
        else if (dir < 0 && timer <= 0)
        {
            dir *= -1;
        }

        rect.localPosition = new Vector3(
            rect.localPosition.x,
            offset + cap.Evaluate(timer),
            rect.localPosition.z);
    }
    public void UpdatePosition(float amount, float max)
    {
        rect.localPosition = new Vector3(
            rect.localPosition.x,
            offset + amount - (max / 2),
            rect.localPosition.z);
    }
}
