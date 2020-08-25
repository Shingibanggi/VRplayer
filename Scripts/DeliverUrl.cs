using UnityEngine;

public class DeliverUrl : MonoBehaviour
{
    public string videoUrl = "";
    private GameObject videotoPlay;

    // Use this for initialization
    void Start()
    {
        //to keep the url on the scene transition
        videotoPlay = this.gameObject;
        DontDestroyOnLoad(videotoPlay);
    }

    public void SetUrl(string Url)
    {
        this.videoUrl = Url;
    }
}
