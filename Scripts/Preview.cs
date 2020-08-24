using UnityEngine;
using UnityEngine.Video;

//play preview : play without sound only when you look at the video
public class Preview : MonoBehaviour
{

    private VideoPlayer player;
    private bool IsLoaded = false;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.SetDirectAudioMute(0, true);
    }

    void Update()
    {
        //Display (first) frame
        if (!IsLoaded)
        {
            if (player.frame >= 10.0f)
            {
                player.Pause();
                IsLoaded = true;
            }
        }
    }

    public void OnPointerEnter()
    {
        player.Play();
    }

    public void OnPointerExit()
    {
        player.Pause();
    }
}
