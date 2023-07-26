using UnityEngine;

public class AsteroidsBullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        rb.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Asteroids Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
