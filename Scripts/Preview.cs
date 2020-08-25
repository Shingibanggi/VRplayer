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
        if (!IsLoaded)
        {
            DisplayThumbnail();
        }
    }

    void DisplayThumbnail()
    {
        if (player.frame >= 10.0f)
        {
            player.Pause();
            IsLoaded = true;
        }
    }

    //Event trigger setting required
    public void OnPointerEnter()
    {
        player.Play();
    }

    //Event trigger setting required
    public void OnPointerExit()
    {
        player.Pause();
    }
}
