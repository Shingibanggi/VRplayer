using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer _player;
    private readonly ushort _nTrack = 1;

    private YoutubePlayer.YoutubePlayer _youtubePlayer;
    public string youtubeUrl;


    private void Awake()
    {
        InitializeVideo();
    }

    // Use this for initialization
    private void Start()
    {
        YoutubePlay();
    }

    private void InitializeVideo()
    {
        _player = GetComponent<VideoPlayer>();
        _player.playOnAwake = true;
        _player.waitForFirstFrame = true;
        _player.isLooping = true;
        _player.playbackSpeed = 1;

        _player.renderMode = VideoRenderMode.MaterialOverride;
        _player.audioOutputMode = VideoAudioOutputMode.Direct;

        _player.controlledAudioTrackCount = _nTrack;
    }

    private void YoutubePlay()
    {
        //Find and enable youtube player componenet
        _youtubePlayer = this.gameObject.GetComponent<YoutubePlayer.YoutubePlayer>();
        _youtubePlayer.youtubeUrl = this.youtubeUrl;

        _youtubePlayer.enabled = true;
    }
}