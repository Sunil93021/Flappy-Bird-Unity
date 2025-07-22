using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    private Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        material.mainTextureOffset += offset*Time.deltaTime;
    }
}
