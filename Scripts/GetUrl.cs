using UnityEngine;
using UnityEngine.Video;

public class GetUrl : MonoBehaviour
{
    string myUrl = "";
    GameObject VideoToPlay;
    VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        VideoToPlay = GameObject.Find("VideoToPlay");
        myUrl = VideoToPlay.GetComponent<DeliverUrl>().url;

        //myurl 을 video player의 url로 넘기기
        player = GetComponent<VideoPlayer>();
        player.url = myUrl;
    }
}
