using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsType
{
    public static void SafeSet<T>(this T[] array, int id, ref T var)
    {
        if (array.Length <= id) { return; }
        var = array[id];
    }
}
