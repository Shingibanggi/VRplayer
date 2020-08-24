using UnityEngine;

public class DeliverUrl : MonoBehaviour
{
    public string url = "";
    public GameObject VideotoPlay;

    void Start()
    {
        VideotoPlay = this.gameObject;
        DontDestroyOnLoad(VideotoPlay);
    }

    public void SetUrl(string _url)
    {
        this.url = _url;
    }
}
