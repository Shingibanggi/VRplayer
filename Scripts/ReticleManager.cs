using UnityEngine;

//영상 보고 있을 때는 포인터 감추기
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
