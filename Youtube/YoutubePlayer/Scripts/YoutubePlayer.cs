using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;
using YoutubeExplode;
using YoutubeExplode.Models.ClosedCaptions;
using YoutubeExplode.Models.MediaStreams;

namespace YoutubePlayer
{
    [RequireComponent(typeof(VideoPlayer))]
    public class YoutubePlayer : MonoBehaviour
    {
        public string youtubeUrl;

        /// <summary>
        /// VideoStartingDelegate 
        /// </summary>
        /// <param name="url">Youtube url (e.g. https://www.youtube.com/watch?v=VIDEO_ID)</param>
        public delegate void VideoStartingDelegate(string url);

        /// <summary>
        /// Event fired when a youtube video is starting
        /// Useful to start downloading captions, etc.
        /// </summary>
        public event VideoStartingDelegate YoutubeVideoStarting;

        private VideoPlayer videoPlayer;
        private YoutubeClient youtubeClient;

        private void Awake()
        {
            youtubeClient = new YoutubeClient();
            videoPlayer = GetComponent<VideoPlayer>();
        }

        private async void OnEnable()
        {
            if (videoPlayer.playOnAwake)
                await PlayVideoAsync();
        }

        /// <summary>
        /// Play the youtube video in the attached Video Player component.
        /// </summary>
        /// <param name="videoUrl">Youtube url (e.g. https://www.youtube.com/watch?v=VIDEO_ID)</param>
        /// <returns>A Task to await</returns>
        /// <exception cref="NotSupportedException">When the youtube url doesn't contain any supported streams</exception>
        public async Task PlayVideoAsync(string videoUrl = null)
        {
            try
            {
                videoUrl = videoUrl ?? youtubeUrl;
                var videoId = GetVideoId(videoUrl);
                var streamInfoSet = await youtubeClient.GetVideoMediaStreamInfosAsync(videoId);
                var streamInfo = streamInfoSet.WithHighestVideoQualitySupported();
                if (streamInfo == null)
                    throw new NotSupportedException($"No supported streams in youtube video '{videoId}'");

                videoPlayer.source = VideoSource.Url;

                //Resetting the same url restarts the video...
                if (videoPlayer.url != streamInfo.Url)
                    videoPlayer.url = streamInfo.Url;

                videoPlayer.Play();
                youtubeUrl = videoUrl;
                YoutubeVideoStarting?.Invoke(youtubeUrl);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        /// <summary>
        /// Download closed captions for a youtube video
        /// </summary>
        /// <param name="videoUrl">Youtube url (e.g. https://www.youtube.com/watch?v=VIDEO_ID)</param>
        /// <returns>A ClosedCaptionTrack object.</returns>
        public async Task<ClosedCaptionTrack> DownloadClosedCaptions(string videoUrl = null)
        {
            videoUrl = videoUrl ?? youtubeUrl;
            var videoId = GetVideoId(videoUrl);
            var trackInfos = await youtubeClient.GetVideoClosedCaptionTrackInfosAsync(videoId);
            if (trackInfos?.Count == 0)
                return null;

            var trackInfo = trackInfos.FirstOrDefault(t => t.Language.Code == "en") ?? trackInfos.First();
            return await youtubeClient.GetClosedCaptionTrackAsync(trackInfo);
        }

        /// <summary>
        /// Try to parse a video ID from a video Url.
        /// If null is passed, it will use the current url of the Youtube Player instance.
        /// </summary>
        /// <param name="videoUrl">Youtube url (e.g. https://www.youtube.com/watch?v=VIDEO_ID)</param>
        /// <returns>The video ID</returns>
        /// <exception cref="ArgumentException">If the videoUrl is not a valid youtube url</exception>
        public string GetVideoId(string videoUrl = null)
        {
            if (!YoutubeClient.TryParseVideoId(videoUrl, out var videoId))
                throw new ArgumentException("Invalid youtube url", nameof(videoUrl));

            return videoId;
        }

    }
}