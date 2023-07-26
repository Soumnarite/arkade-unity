using UnityEngine;

public class PongBall : MonoBehaviour
{   
    [SerializeField] float speed;
    [SerializeField] ParticleSystem ballEffect;

    Rigidbody2D rb;

    PongScoreKeeper scoreKeeper;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreKeeper = FindObjectOfType<PongScoreKeeper>();
        PongResetBall();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            PongResetBall();
        }
    }

    void FixedUpdate() 
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void LaunchBall()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = Random.Range(-0.5f, 0.5f);
        rb.AddForce(force.normalized * speed);
    }

    public void PongResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Wall Left")
        {
            scoreKeeper.AddScore2();
            scoreKeeper.DrawScore2();
            PongResetBall();
        }
        else if(other.gameObject.name == "Wall Right")
        {
            scoreKeeper.AddScore1();
            scoreKeeper.DrawScore1();
            PongResetBall();
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        ballEffect.Play();
    }
}
