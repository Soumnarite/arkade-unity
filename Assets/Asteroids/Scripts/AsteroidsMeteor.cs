using UnityEngine;

public class AsteroidsMeteor : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;

    [SerializeField] float speed;

    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    [SerializeField] float maxLifeTime;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    AsteriodsGameManager gameManager;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<AsteriodsGameManager>();
    }

    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        transform.localScale = Vector3.one * size;
        rb.mass = size;
    }

    public void AsteroidsMeteorSetTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * speed);
        Destroy(gameObject, maxLifeTime);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Asteroids Bullet")
        {
            if((size / 2.0f) >= minSize)
            {
                SplitMeteors();
                SplitMeteors();
            }

            gameManager.AsteroidsMeteorDestroyed(this);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    void SplitMeteors()
    {
        Vector2 pos = transform.position;
        pos += Random.insideUnitCircle * 0.5f;

        AsteroidsMeteor half = Instantiate(this, pos, transform.rotation);

        half.size = size / 2.0f;
        half.AsteroidsMeteorSetTrajectory(Random.insideUnitCircle.normalized);
    }
}
