using UnityEngine;

public class ReticleManager : MonoBehaviour
{
    private MeshRenderer _pointerRenderer;

    // Use this for initialization
    private void Start()
    {
        _pointerRenderer = GameObject.Find("GvrReticlePointer").GetComponent<MeshRenderer>();
    }


    public void HideReticle()
    {
        _pointerRenderer.enabled = false;
    }

    public void ShowReticle()
    {
        _pointerRenderer.enabled = true;
    }
}
