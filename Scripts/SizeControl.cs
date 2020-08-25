using UnityEngine;
using UnityEngine.Video;

//Control the video size
public class SizeControl : MonoBehaviour
{
    private VideoPlayer _player;
    private GameObject _parent;

    public AnimationClip expandingClip;
    public AnimationClip reducingClip;

    void Start()
    {
        _player = GetComponent<VideoPlayer>();
        _player.SetDirectAudioMute(0, true);

        _parent = transform.parent.gameObject;
    }

    public void ExpandVideo()
    {
        //set the animation clip and play it
        _parent.GetComponent<Animation>().clip = expandingClip;
        _parent.GetComponent<Animation>().Play();

        //Unmute and play video
        _player.SetDirectAudioMute(0, false);
        _player.Play();
    }

    public void ReduceVideo()
    {
        //Pause and mute the video 
        _player.Pause();
        _player.SetDirectAudioMute(0, true);

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