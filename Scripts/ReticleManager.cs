using UnityEngine;

//Hide pointer when watching video
public class ReticleManager : MonoBehaviour
{
    public MeshRenderer Renderer;

    private void Start()
    {
        Renderer = GameObject.Find("GvrReticlePointer").GetComponent<MeshRenderer>();
    }


    public void OnPointerEnter()
    {
        Renderer.enabled = false;
    }

    public void OnPointerExit()
    {
        Renderer.enabled = true;
    }
}
