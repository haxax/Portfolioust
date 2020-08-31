using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Networking;

[AddComponentMenu("")]
public class ProjectCardUI : CardUI
{
    [HideInInspector] [SerializeField] private ProjectCard projectCard;
    public ProjectCard ProjectCard { get => projectCard; private set => projectCard = value; }

    [SerializeField] private Text titleTxt;
    [SerializeField] private Text descTxt;
    [SerializeField] private Text dateTxt;
    [SerializeField] private Text platformTxt;
    [SerializeField] private Text teamTxt;

    [SerializeField] private Image tierImage;

    [SerializeField] private ButtonURL homeButton;

    [SerializeField] private Text videoTxt;
    [SerializeField] private ButtonURL videoButton;
    [SerializeField] private ImagePlayer videoThumbnailPlayer;

    protected virtual void OnValidate()
    {
        this.ValidateComponent(ref projectCard);
        this.ValidateComponentInChildren(ref titleTxt, "TitleTxt");
        this.ValidateComponentInChildren(ref descTxt, "DescTxt");
        this.ValidateComponentInChildren(ref dateTxt, "DateTxt");
        this.ValidateComponentInChildren(ref platformTxt, "PlatformTxt");
        this.ValidateComponentInChildren(ref teamTxt, "TeamTxt");
        this.ValidateComponentInChildren(ref homeButton, "HomeButton");
        this.ValidateComponentInChildren(ref tierImage, "TierImage");

        this.ValidateComponentInChildren(ref videoTxt, "VideoTxt");
        this.ValidateComponentInChildren(ref videoButton, "Video");
        this.ValidateComponentInChildren(ref videoThumbnailPlayer, "VideoImage");
    }

    public override void UpdateContent()
    {
        base.UpdateContent();
        titleTxt.text = ProjectCard.Data.Title;
        descTxt.text = ProjectCard.Data.Desc;
        dateTxt.text = ProjectCard.Data.Date;
        platformTxt.text = ProjectCard.Data.Platform;
        teamTxt.text = ProjectCard.Data.Team;

        tierImage.color = UISettingsSO.Instance.GetTierColor(ProjectCard.Data.Tier);
        SetupHomeLink();
        SetupVideoLink();
        StartCoroutine(LoadVideoThumbnails());
    }

    public override Card Card()
    { return ProjectCard; }


    /// <summary>
    /// Loads YouTube thumbnails as images for ImagePlayer to show
    /// </summary>
    /// <returns>Returns after images loaded</returns>
    private IEnumerator LoadVideoThumbnails()
    {
        List<Sprite> result = new List<Sprite>();

        if (ProjectCard.Data.VideoId != "")
        {
            for (int i = 1; i <= 3; i++)
            {
                using (UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://i.ytimg.com/vi/" + ProjectCard.Data.VideoId + "/hq" + i + ".jpg"))
                {
                    yield return request.SendWebRequest();
                    Texture2D newTexture = DownloadHandlerTexture.GetContent(request);
                    if (newTexture != null)
                    {
                        result.Add(Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f)));
                    }
                }
            }
        }
        SetupVideoThumbnails(result);
    }

    /// <summary>
    /// Set images to ImagePlayer
    /// </summary>
    /// <param name="sprites">ImagePlayer frames</param>
    private void SetupVideoThumbnails(List<Sprite> sprites)
    {
        if (sprites.Count > 0)
        {
            videoThumbnailPlayer.Setup(sprites);
        }
    }

    private void SetupVideoLink()
    {
        if (ProjectCard.Data.Video != "")
        {
            videoButton.URL = ProjectCard.Data.Video;
            videoTxt.text = UISettingsSO.Instance.PublicVideoTxt;
        }
        else
        {
            videoButton.Button.enabled = false;
            videoTxt.text = UISettingsSO.Instance.PrivateVideoTxt;
        }
    }

    private void SetupHomeLink()
    {
        if (ProjectCard.Data.Link != "")
        { homeButton.URL = ProjectCard.Data.Link; }
        else
        { homeButton.Button.enabled = false; }
    }
}