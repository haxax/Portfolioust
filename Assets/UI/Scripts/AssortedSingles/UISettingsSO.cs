using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Global settings for various UI elements
/// </summary>

[CreateAssetMenu(fileName = "UISettings", menuName = "UI/UISettings", order = 500)]
public class UISettingsSO : SingletonSO<UISettingsSO>
{
    [Tooltip("Used by ImagePlayers without content by default")]
    [SerializeField] private ImagePlayerSettings emptyImagePlayerSettings = new ImagePlayerSettings();
    [Tooltip("Used by ImagePlayers with content by default")]
    [SerializeField] private ImagePlayerSettings defaultImagePlayerSettings = new ImagePlayerSettings();
    [Space(10)]

    [SerializeField] private string privateVideoTxt = "<b>This video is private or doesn't exist\nContact to watch</b>";
    [SerializeField] private string publicVideoTxt = "<b>Tap to watch on YouTube</b>";
    [Space(10)]

    [Tooltip("Tier specific colors used by cards")]
    [SerializeField] private List<StringColorPair> tierColors = new List<StringColorPair>();

    public ImagePlayerSettings EmptyImagePlayerSettings { get => emptyImagePlayerSettings; }
    public ImagePlayerSettings DefaultImagePlayerSettings { get => defaultImagePlayerSettings; }
    public string PrivateVideoTxt { get => privateVideoTxt; }
    public string PublicVideoTxt { get => publicVideoTxt; }



    /// <summary>
    /// Returns matching tier specific color
    /// </summary>
    /// <param name="tierId">Tier id of a card</param>
    /// <returns>Color of the tier</returns>
    public Color GetTierColor(string tierId)
    {
        for (int i = 0; i < tierColors.Count; i++)
        {
            if (tierId == tierColors[i].Id)
            { return tierColors[i].Color; }
        }
        Debug.LogWarning("Tier not found. Use valid tier.");
        return Color.clear;
    }

    [System.Serializable]
    public class StringColorPair
    {
        [Tooltip("Id should match an id used in cards")]
        [SerializeField] private string id = "0";
        [SerializeField] private Color color = Color.white;

        public string Id { get => id; }
        public Color Color { get => color; }
    }
}