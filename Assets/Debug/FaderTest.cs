using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderTest : MonoBehaviour
{
    [SerializeField] private Vector2 cap = Vector2.zero;
    [SerializeField] private Fader fader;
    [SerializeField] private RectTransform rect;

    private void OnValidate()
    {
        this.ValidateComponent(ref fader);
        this.ValidateComponent(ref rect);
    }

    void Update()
    {
        float value = (rect.localPosition.y - cap.x) / (cap.y - cap.x);
        fader.UpdateState(value);
    }
}
