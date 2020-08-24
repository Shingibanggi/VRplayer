using UnityEngine;
using UnityEngine.Video;

public class VideoSetting : MonoBehaviour
{
    private VideoPlayer player;
    private ushort track_num = 1;

    void Awake()
    {
        player = GetComponent<VideoPlayer>();
        player.playOnAwake = true;
        player.waitForFirstFrame = true;
        player.isLooping = true;
        player.playbackSpeed = 1;

        player.renderMode = VideoRenderMode.MaterialOverride;
        player.audioOutputMode = VideoAudioOutputMode.Direct;

        player.controlledAudioTrackCount = track_num;
    }

}