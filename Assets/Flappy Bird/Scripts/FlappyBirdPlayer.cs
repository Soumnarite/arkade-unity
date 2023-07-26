using UnityEngine;

public class FlappyBirdPlayer : MonoBehaviour
{
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float force;
    [SerializeField] float tilt;

    [SerializeField] Sprite[] sprites;
    int spriteIndex;

    Vector3 direction;

    SpriteRenderer spriteRenderer;
    FlappyBirdGameManager gameManager;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        gameManager = FindObjectOfType<FlappyBirdGameManager>();
        InvokeRepeating("SpriteLoop", 0.15f, 0.15f);
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * force;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    void Rotate()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    public void FlappyBirdReset()
    {
        Vector3 startPos = new Vector3(0, 3.4f, 0);
        transform.position = startPos;
        direction = Vector3.zero;
    }

    void SpriteLoop()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Flappy Bird Obstacle")
        {
            gameManager.FlappyBirdGameOver();
        }
        else if(other.gameObject.name == "Score Trigger")
        {
            gameManager.FlappyBirdAddScore();
        }
    }
}
