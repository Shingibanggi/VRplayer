using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ButtonMananger : MonoBehaviour
{ 
    private static bool _isPlayScene = false;  
    private bool _triggerEnter = false;
    private float _progress = 0f;
    private Image _playButton;

    private void Awake()
    {
        InitializeButton();
    }

    private void Update()
    {
        if (_triggerEnter)
        {
            FillButtonGauge();

            if (_progress >= 1f)
            {
                ChangeScene();
            }
        }
    }

    //Change the scene (PlayScene <-> MainScene)
    private void ChangeScene()
    {
        if (!_isPlayScene)
        {
            _isPlayScene = true;
            SetUrl();
            SceneManager.LoadScene("PlayVideo");
        }
        else
        {
            _isPlayScene = false;
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void InitializeButton()
    {
        _playButton = GetComponent<Image>();
        _playButton.type = Image.Type.Filled;
        _playButton.fillMethod = Image.FillMethod.Radial360;
        _playButton.fillAmount = 0f;
    }

    //The button gauge fills up when the user's gaze is reached
    private void FillButtonGauge()
    {
        if (_triggerEnter)
        {
            _progress += Time.deltaTime;
            _playButton.fillAmount = _progress;
        }
    }

    private void SetUrl()
    {
        //Find the url playing now
        GameObject pparent = transform.parent.gameObject.transform.parent.gameObject;
        GameObject video = pparent.transform.Find("video").gameObject;
        string myurl = video.GetComponent<VideoPlayer>().url;

        //Set the url to play in PlayScene
        GameObject.Find("videoToPlay").GetComponent<DeliverUrl>().SetUrl(myurl);
    }


    //Event trigger setting required
    public void OnPointerEnter()
    {
        _triggerEnter = true;
    }

    //Event trigger setting required
    public void OnPointerExit()
    {
        _triggerEnter = false;
        _progress = 0f;
        _playButton.fillAmount = 0f;
    }
}
