using UnityEngine;

public class CentipedeDart : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    Transform parent;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        parent = transform.parent;
    }

    void Update()
    {
        if(rb.isKinematic && Input.GetKeyDown(KeyCode.Space))
        {
            transform.SetParent(null);
            rb.bodyType = RigidbodyType2D.Dynamic;
            boxCollider.enabled = true;
        }
    }

    void FixedUpdate()
    {
        if(!rb.isKinematic)
        {
            Vector2 pos = rb.position;
            pos += Vector2.up * speed * Time.fixedDeltaTime;
            rb.MovePosition(pos);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        transform.SetParent(parent);
        transform.localPosition = new Vector3(0f, 0.5f, 0f);
        rb.bodyType = RigidbodyType2D.Kinematic;
        boxCollider.enabled = false;
    }
}
