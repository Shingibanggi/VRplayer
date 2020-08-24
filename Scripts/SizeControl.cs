using System.Collections;
using System.Collections.Generic;
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
    }

    public void ExpandVideo()
    {
        parent = transform.parent.gameObject;

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
}