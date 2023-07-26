using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvadersAlien : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] float animationTime;
    int animationFrame;

    SpriteRenderer spriteRenderer;

    public System.Action killed;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InvokeRepeating("AnimateSprites", animationTime, animationTime);
    }

    void AnimateSprites()
    {
        animationFrame++;

        if(animationFrame >= sprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = sprites[animationFrame];
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Space Invaders Laser"))
        {
            killed.Invoke();
            gameObject.SetActive(false);
        }
    }
}
