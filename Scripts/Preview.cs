using UnityEngine;
using UnityEngine.Video;

//play preview : play without sound only when you look at the video
public class Preview : MonoBehaviour
{

    private VideoPlayer _player;
    private bool _isLoaded = false;

    private void Start()
    {
        _player = GetComponent<VideoPlayer>();
        _player.SetDirectAudioMute(0, true);
    }

    private void Update()
    {
        if (!_isLoaded)
        {
            DisplayThumbnail();
        }
    }

    private void DisplayThumbnail()
    {
        if (_player.frame >= 10.0f)
        {
            _player.Pause();
            _isLoaded = true;
        }
    }

    //Event trigger setting required
    public void OnPointerEnter()
    {
        _player.Play();
    }

    //Event trigger setting required
    public void OnPointerExit()
    {
        _player.Pause();
    }
}
