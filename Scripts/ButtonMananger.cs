using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ButtonMananger : MonoBehaviour
{ 
    static bool PlayScene = false;  
    bool triggerEnter = false;
    float progress = 0f;

    private Image playButton;

    private void Awake()
    {
        ButtonInitialSetting();
    }

    void Update()
    {
        if (triggerEnter)
        {
            FillButtonGauge();

            if (progress >= 1f)
            {
                ChangeScene();
            }
        }
    }

    //Change the scene (PlayScene <-> MainScene)
    void ChangeScene()
    {
        if (!PlayScene)
        {
            PlayScene = true;
            SetUrl();
            SceneManager.LoadScene("PlayVideo");
        }
        else
        {
            PlayScene = false;
            SceneManager.LoadScene("MainMenu");
        }
    }

    void ButtonInitialSetting()
    {
        playButton = GetComponent<Image>();
        playButton.type = Image.Type.Filled;
        playButton.fillMethod = Image.FillMethod.Radial360;
        playButton.fillAmount = 0f;
    }

    //The button gauge fills up when the user's gaze is reached
    private void FillButtonGauge()
    {
        if (triggerEnter)
        {
            progress = progress + Time.deltaTime;
            playButton.fillAmount = progress;
        }
    }

    void SetUrl()
    {
        string myurl = "";

        //Find the url playing now
        GameObject pparent = transform.parent.gameObject.transform.parent.gameObject;
        GameObject video = pparent.transform.Find("video").gameObject;
        myurl = video.GetComponent<VideoPlayer>().url;

        //Set the url to play in PlayScene
        GameObject.Find("VideoToPlay").GetComponent<DeliverUrl>().SetUrl(myurl);
    }


    //Event trigger setting required
    public void OnPointerEnter()
    {
        triggerEnter = true;
    }

    //Event trigger setting required
    public void OnPointerExit()
    {
        triggerEnter = false;
        progress = 0f;
        playButton.fillAmount = 0f;
    }
}
