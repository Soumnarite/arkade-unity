using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBrick : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[0];
    [SerializeField] bool unbreakable;

    int health;

    SpriteRenderer spriteRenderer;

    BreakoutGameManager gameManager;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<BreakoutGameManager>();
    }

    void Start()
    {
        BreakoutResetBricks();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            BreakoutResetBricks();
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        BreakBricks();
    }

    public void BreakoutResetBricks()
    {
        gameObject.SetActive(true);

        if (!unbreakable)
        {
            health = sprites.Length;
            spriteRenderer.sprite = sprites[health - 1];
        }
    }

    void BreakBricks()
    {
        if(unbreakable)
        {
            return;
        }

        gameManager.BreakoutAddScore(75);

        health--;

        if(health == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
           spriteRenderer.sprite = sprites[health - 1];
        }
    }
}
