using UnityEngine;
using UnityEngine.Video;

//미리보기 플레이 (영상 바라보면 소리없이 재생)
public class Preview : MonoBehaviour
{

    private VideoPlayer player;
    //private bool triggerEnter = false;
    private bool IsLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.SetDirectAudioMute(0, true);  //0번째 트랙 뮤트
    }

    // Update is called once per frame
    void Update()
    {
        //썸네일 화면 띄워두기
        if (!IsLoaded)
        {
            if (player.frame >= 10.0f)
            {
                player.Pause();
                IsLoaded = true;
            }
        }

        //if (!triggerEnter && player.isPlaying)
        //{
        //    player.Pause();
        //}
        //영상 2, 3 안멈추고 계속 재생되는 문제 해결 필요
    }

    public void OnPointerEnter()
    {
        //triggerEnter = true;
        player.Play();
    }

    public void OnPointerExit()
    {
        //triggerEnter = false;
        player.Pause();
    }


}
