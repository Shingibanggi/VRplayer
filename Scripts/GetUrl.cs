using UnityEngine;
using UnityEngine.Video;

public class GetUrl : MonoBehaviour
{
    string myUrl = "";
    GameObject VideoToPlay;
    VideoPlayer player;

    void Start()
    {
        VideoToPlay = GameObject.Find("VideoToPlay");
        myUrl = VideoToPlay.GetComponent<DeliverUrl>().url;

        //pass myurl to the url of video player
        player = GetComponent<VideoPlayer>();
        player.url = myUrl;
    }
}
