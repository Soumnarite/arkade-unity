using UnityEngine;

public class BreakoutPlayer : MonoBehaviour
{
    [SerializeField] float speed;

    float maxBounceAngle = 75f;

    Vector3 direction;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.zero;
        }

        rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void BreakoutResetPaddle()
    {
        transform.position = new Vector2(0, transform.position.y);
        rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        BreakoutBall ball = other.gameObject.GetComponent<BreakoutBall>();

        if(ball != null)
        {
            Vector3 paddlePosition = transform.position;

            // Position of the collision, (0) means first collision.
            Vector2 contactPoint = other.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = other.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }
}
