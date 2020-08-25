using UnityEngine;
using UnityEngine.Video;

public class GetUrl : MonoBehaviour
{
    private string _Url = "";
    private VideoPlayer _player;

    public GameObject videoToPlay;

    private void Start()
    {
        getUrl();
    }

    private void getUrl()
    {
        //Find the url passed by MainScene
        videoToPlay = GameObject.Find("videoToPlay");
        _Url = videoToPlay.GetComponent<DeliverUrl>().videoUrl;

        //Set the url to play
        _player = GetComponent<VideoPlayer>();
        _player.url = _Url;
    }
}