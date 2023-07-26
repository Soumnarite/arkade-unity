using UnityEngine;

public class DonkeyKongPrincess : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, 0f);
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        speed = -speed;
        transform.localScale = new Vector2 (-(Mathf.Sign(rb.velocity.x)), 1f);
    }
}
