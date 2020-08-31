using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImagePlayer : MonoBehaviour
{
    [HideInInspector] [SerializeField] private Image image;

    [SerializeField] private ImagePlayerSettings settings;
    public ImagePlayerSettings Settings { get => settings; set => settings = value; }

    public bool IsPlaying { get; private set; } = false;

    private int currentSprite = 0;
    private int CurrentSprite
    {
        get => currentSprite;
        set
        {
            currentSprite = value;
            // Keep current sprite within valid range all the time
            if (currentSprite >= Settings.Sprites.Count)
            { currentSprite = 0; }
            else if (currentSprite < 0)
            { currentSprite = Settings.Sprites.Count - 1; }
            // Change sprite automatically if value changes
            image.sprite = Settings.Sprites[currentSprite];
        }
    }

    private float timer = 0.00f;
    private float Timer
    {
        get => timer;
        set
        {
            // Automatically change sprite if 0 or 1 reached
            // Could support inverse looping
            timer = value;
            if (timer >= 1f)
            {
                timer -= 1f;
                CurrentSprite++;
            }
            else if (timer < 0f)
            {
                timer += 1f;
                CurrentSprite--;
            }
        }
    }

    private void OnValidate()
    {
        this.ValidateComponent(ref image);
    }

    private void Start()
    {
        if (Settings.Sprites.Count == 0)
        { SetupToEmpty(); }

        RefreshImage();
    }

    private void Update()
    {
        Timer += Time.deltaTime / Settings.SpriteDuration;
        image.color = image.color.ChangeAlpha(Settings.AlphaCurve.Evaluate(Timer));
    }

    public void Reset()
    {
        Timer = 0.5f;
        CurrentSprite = 0;
        RefreshImage();
    }
    public void Play()
    {
        this.enabled = true;
    }
    public void Stop()
    {
        this.enabled = false;
        Reset();
    }
    public void Pause()
    {
        this.enabled = false;
    }

    public void RefreshImage()
    {
        image.sprite = Settings.Sprites[currentSprite];
        image.color = image.color.ChangeAlpha(Settings.AlphaCurve.Evaluate(Timer));
    }

    /// <summary>
    /// Set global settings of empty player
    /// </summary>
    public void SetupToEmpty()
    {
        Settings = new ImagePlayerSettings(UISettingsSO.Instance.EmptyImagePlayerSettings);
    }

    /// <summary>
    /// Set player to use list of sprites using global settings
    /// </summary>
    public void Setup(List<Sprite> sprites)
    {
        Settings = new ImagePlayerSettings(UISettingsSO.Instance.DefaultImagePlayerSettings);
        Settings.Sprites = sprites;
    }
}




[System.Serializable]
public class ImagePlayerSettings
{
    public ImagePlayerSettings()
    {
        SpriteDuration = 1f;
        AlphaCurve = new AnimationCurve();
        Sprites = new List<Sprite>();
    }

    public ImagePlayerSettings(ImagePlayerSettings settings)
    {
        SpriteDuration = settings.SpriteDuration;
        AlphaCurve = settings.AlphaCurve;
        Sprites = settings.Sprites;
    }

    [Tooltip("Duration how long each sprite is shown")]
    [SerializeField] private float spriteDuration = 1f;
    public float SpriteDuration { get => spriteDuration; set => spriteDuration = value; }

    [Tooltip("Alpha level of the current image within duration")]
    [SerializeField] private AnimationCurve alphaCurve = new AnimationCurve();
    public AnimationCurve AlphaCurve { get => alphaCurve; set => alphaCurve = value; }

    [Tooltip("List of looping sprites")]
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    public List<Sprite> Sprites { get => sprites; set => sprites = value; }
}