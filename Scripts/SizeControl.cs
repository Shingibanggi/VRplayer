using UnityEngine;
using UnityEngine.Video;

public class SizeControl : MonoBehaviour
{
    private VideoPlayer player;
    private GameObject parent;

    public AnimationClip Expand_clip;
    public AnimationClip Reduce_clip;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.SetDirectAudioMute(0, true);

        parent = transform.parent.gameObject;
    }

    public void ExpandVideo()
    {
        parent.GetComponent<Animation>().clip = Expand_clip;
        parent.GetComponent<Animation>().Play();

        player.SetDirectAudioMute(0, false);
        player.Play();
    }

    public void ReduceVideo()
    {
        player.Pause();
        player.SetDirectAudioMute(0, true);

        parent.GetComponent<Animation>().clip = Reduce_clip;
        parent.GetComponent<Animation>().Play();
    }


    //스크립트 변수를 애니메이션 클립 파라미터로 쓰고 싶다
    //public Vector3 origin_pos = new Vector3(0f, 150f, 87f);
    //public Vector3 origin_scale = new Vector3(0.3f, 0.3f, 0.3f);

    //public Vector3 target_pos = new Vector3(0f, -750f, 80f);
    //public Vector3 target_scale = new Vector3(1.7f, 1.7f, 1.7f);

}