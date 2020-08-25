using UnityEngine;

//Hide pointer when watching video
public class ReticleManager : MonoBehaviour
{
    private MeshRenderer _pointerRenderer;

    private void Start()
    {
        _pointerRenderer = GameObject.Find("GvrReticlePointer").GetComponent<MeshRenderer>();
    }


    public void OnPointerEnter()
    {
        _pointerRenderer.enabled = false;
    }

    public void OnPointerExit()
    {
        _pointerRenderer.enabled = true;
    }
}
