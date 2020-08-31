using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsList
{
    /// <summary>
    /// Invokes action once per object in the list using the object as a parameter
    /// </summary>
    /// <param name="list">List of parameters</param>
    /// <param name="action">Action to be invoked</param>
    public static void InverseLoop<T>(this List<T> list, Action<T> action)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            action.Invoke(list[i]);
        }
    }
}
