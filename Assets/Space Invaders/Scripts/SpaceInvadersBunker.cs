using UnityEngine;

public class SpaceInvadersBunker : MonoBehaviour
{
    [SerializeField] Sprite splat;

    int health = 2;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Space Invaders Alien")) 
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Space Invaders Missile")) 
        {
            health--;
            ChangeBunkerState();
        }
    }

    void ChangeBunkerState()
    {
        if(health == 1)
        {
            spriteRenderer.sprite = splat;
        }
        else if(health == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
