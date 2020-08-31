using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsColor
{
    /// <summary>
    /// Easier way to change just the alpha value of a color
    /// </summary>
    public static Color ChangeAlpha(this Color color, float amount)
    { return new Color(color.r, color.g, color.b, amount); }
}
