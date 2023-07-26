using UnityEngine;

public class FlappyBirdParallax : MonoBehaviour
{
    [SerializeField] float scrollSpeed;

    MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
