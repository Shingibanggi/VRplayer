using UnityEngine;

public class DeliverUrl : MonoBehaviour
{
    public string url = "";
    public GameObject VideotoPlay;

    void Start()
    {
        //to keep the url on the scene transition
        VideotoPlay = this.gameObject;
        DontDestroyOnLoad(VideotoPlay);
    }

    public void SetUrl(string _url)
    {
        this.url = _url;
    }
}
