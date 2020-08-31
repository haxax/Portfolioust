using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollInputDebug : MonoBehaviour
{
    public float speed = 1f;
    public List<Scroller> scrollers = new List<Scroller>();

    void Update()
    {
        float input = Input.mouseScrollDelta.y * speed;
        foreach (Scroller sc in scrollers)
        {
            sc.AddForce(input, ScrollDirection.any);
        }
    }
}
