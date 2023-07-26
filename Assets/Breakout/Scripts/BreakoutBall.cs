using UnityEngine;

public class BreakoutBall : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;

    BreakoutGameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<BreakoutGameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        BreakoutResetBall();
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    public void BreakoutResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;

        Invoke("LaunchBall", 2f);
    }

    void LaunchBall()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rb.AddForce(force.normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Wall Down")
        {
            gameManager.BreakoutCheckLives();
        }
    }
}
