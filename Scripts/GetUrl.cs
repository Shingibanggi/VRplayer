using UnityEngine;
using UnityEngine.Video;

public class GetUrl : MonoBehaviour
{
    string myUrl = "";
    GameObject VideoToPlay;
    VideoPlayer player;

    void Start()
    {
        getUrl();
    }

    void getUrl()
    {
        //Find the url passed by MainScene
        VideoToPlay = GameObject.Find("VideoToPlay");
        myUrl = VideoToPlay.GetComponent<DeliverUrl>().url;

        //Set the url to play
        player = GetComponent<VideoPlayer>();
        player.url = myUrl;
    }
}
