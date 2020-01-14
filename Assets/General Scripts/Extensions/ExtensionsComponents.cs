using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsComponent
{
    public static void ValidateComponent<T>(this GameObject obj, ref T component) where T : Component
    {
        if (component == null)
        { component = obj.GetComponent<T>(); }
    }
}
