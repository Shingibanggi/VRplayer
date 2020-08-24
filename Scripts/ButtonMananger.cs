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
        //Init Button
        playButton = GetComponent<Image>();
        playButton.type = Image.Type.Filled;
        playButton.fillMethod = Image.FillMethod.Radial360;
        playButton.fillAmount = 0f;
    }


    // Update is called once per frame
    void Update()
    {
        if (triggerEnter)
        {
            progress = progress + Time.deltaTime;

            playButton.fillAmount = progress;

            if (progress >= 1f)
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
        }
    }

    public void OnPointerEnter()
    {
        triggerEnter = true;
    }

    public void OnPointerExit()
    {
        triggerEnter = false;
        progress = 0f;
        playButton.fillAmount = 0f;
    }

    void SetUrl()
    {
        string myurl = "";

        //현재 url 찾기
        GameObject pparent = transform.parent.gameObject.transform.parent.gameObject;
        GameObject video = pparent.transform.Find("video").gameObject;
        myurl = video.GetComponent<VideoPlayer>().url;

        GameObject.Find("VideoToPlay").GetComponent<DeliverUrl>().SetUrl(myurl);
    }
}
