using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer player;
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
        player = GetComponent<VideoPlayer>();
        player.playOnAwake = true;
        player.waitForFirstFrame = true;
        player.isLooping = true;
        player.playbackSpeed = 1;

        player.renderMode = VideoRenderMode.MaterialOverride;
        player.audioOutputMode = VideoAudioOutputMode.Direct;

        player.controlledAudioTrackCount = _nTrack;
    }

    private void YoutubePlay()
    {
        //Find and enable youtube player componenet
        _youtubePlayer = this.gameObject.GetComponent<YoutubePlayer.YoutubePlayer>();
        _youtubePlayer.youtubeUrl = this.youtubeUrl;

        _youtubePlayer.enabled = true;
    }

    public void Play()
    {
        player.Play();
    }

    public void Pause()
    {
        player.Pause();
    }

    public void Mute()
    {
        player.SetDirectAudioMute(0, true);
    }

    public void Unmute()
    {
        player.SetDirectAudioMute(0, false);
    }
}
