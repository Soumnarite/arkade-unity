using UnityEngine;

public class DonkeyKongMario : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] Sprite[] runSprites;
    [SerializeField] Sprite climbSprite;
    int spriteIndex;

    bool isClimbing;
    bool isGrounded;

    Vector2 direction;
    
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Collider2D capsuleCollider;
    Collider2D[] overlaps = new Collider2D[4];

    DonkeyKongGameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<DonkeyKongGameManager>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void OnEnable()
    {
        InvokeRepeating("AnimateSprite", 1f/12f, 1f/12f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Update()
    {
        CheckCollisions();
        SetDirection();
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Donkey Kong Barrel")
        {
            gameManager.DonkeyKongProcessLives();
        }

        if(other.gameObject.tag == "Princess")
        {
            
        }
    }

    void SetDirection()
    {
        direction.x = Input.GetAxis("Horizontal");

        if(isGrounded)
        {
            direction.y = Mathf.Max(direction.y, -1f);
        }

        if(direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if(direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }

        if(isClimbing)
        {
            direction.y = Input.GetAxis("Vertical");
        }
        else if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector2.up * jumpForce;
        }
        else
        {
            direction += Physics2D.gravity * Time.deltaTime;
        }
    }

    void CheckCollisions()
    {
        isGrounded = false;
        isClimbing = false;

        Vector3 size = capsuleCollider.bounds.size;
        size.y += 0.1f;
        size.x /= 2f;

        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0, overlaps);

        for (int i = 0; i < amount; i++)
        {
            GameObject hit = overlaps[i].gameObject;

            if (hit.layer == LayerMask.NameToLayer("Donkey Kong Ground"))
            {
                isGrounded = hit.transform.position.y < (transform.position.y - 0.5f);
                Physics2D.IgnoreCollision(overlaps[i], capsuleCollider, !isGrounded);
            }
            else if (hit.layer == LayerMask.NameToLayer("Donkey Kong Ladder"))
            {
                isClimbing = true;
            }
        }
    }

    void AnimateSprite()
    {
        if(isClimbing)
        {
            spriteRenderer.sprite = climbSprite;
        }
        else if(direction.x != 0)
        {
            spriteIndex++;

            if (spriteIndex >= runSprites.Length) 
            {
                spriteIndex = 0;
            }

            spriteRenderer.sprite = runSprites[spriteIndex];
        }
    }
}
