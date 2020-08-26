using UnityEngine;
using UnityEngine.Video;

public class GetUrl : MonoBehaviour
{
    private string _Url = "";
    private VideoPlayer _player;

    // Use this for initialization
    private void Start()
    {
        GetYoutubeUrl();
    }

    private void GetYoutubeUrl()
    {
        //Find the url passed by MainScene
        _Url = GameObject.Find("videoToPlay").GetComponent<DeliverUrl>().videoUrl;

        //Set the url to play
        _player = GetComponent<VideoPlayer>();
        _player.url = _Url;
    }
}