using UnityEngine;

public class CentipedeShroom : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    int health;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = sprites.Length;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Centipede Dart"))
        {
            Damage(1);
        }
    }

    void Damage(int amount)
    {
        health -= amount;

        if(health > 0)
        {
            spriteRenderer.sprite = sprites[sprites.Length - health];
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CentipedeHealShrooms()
    {
        health = sprites.Length;
        spriteRenderer.sprite = sprites[0];
    }
}
