using UnityEngine;
using UnityEngine.Video;

//play preview : play without sound only when you look at the video
public class Preview : MonoBehaviour
{

    private VideoManager _video;
    private bool _isLoaded = false;

    // Use this for initialization
    private void Start()
    {
        _video = GetComponent<VideoManager>();
        _video.Mute();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_isLoaded)
        {
            DisplayThumbnail();
        }
    }

    private void DisplayThumbnail()
    {
        if (_video.player.frame >= 10.0f)
        {
            _video.Pause();
            _isLoaded = true;
        }
    }
    
    //Event trigger setting required
    public void OnPointerEnter()
    {
        _video.Play();
    }

    //Event trigger setting required
    public void OnPointerExit()
    {
        _video.Pause();
    }
}
