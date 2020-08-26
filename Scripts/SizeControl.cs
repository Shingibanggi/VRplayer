using UnityEngine;
using UnityEngine.Video;

//Control the video size
public class SizeControl : MonoBehaviour
{
    private VideoManager _video;
    private GameObject _parent;

    public AnimationClip expandingClip;
    public AnimationClip reducingClip;

    // Use this for initialization
    void Start()
    {
        _video = GetComponent<VideoManager>();
        _video.Mute();
        _parent = transform.parent.gameObject;
    }

    public void ExpandVideo()
    {
        //set the animation clip and play it
        _parent.GetComponent<Animation>().clip = expandingClip;
        _parent.GetComponent<Animation>().Play();

        //Unmute and play video
        _video.Unmute();
        _video.Play();
    }

    public void ReduceVideo()
    {
        //Pause and mute the video 
        _video.Pause();
        _video.Mute();

        //set the animation clip and play
        _parent.GetComponent<Animation>().clip = reducingClip;
        _parent.GetComponent<Animation>().Play();
    }


    //스크립트 변수를 애니메이션 클립 파라미터로 쓰고 싶다
    //public Vector3 origin_pos = new Vector3(0f, 150f, 87f);
    //public Vector3 origin_scale = new Vector3(0.3f, 0.3f, 0.3f);

    //public Vector3 target_pos = new Vector3(0f, -750f, 80f);
    //public Vector3 target_scale = new Vector3(1.7f, 1.7f, 1.7f);

}