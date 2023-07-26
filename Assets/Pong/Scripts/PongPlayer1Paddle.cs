using UnityEngine;

public class PongPlayer1Paddle : MonoBehaviour
{
    [SerializeField] float speed;

    Vector2 direction;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetPosition();
    }

    void Update()
    {
        MoveInput();
    }

    void FixedUpdate()
    {
        if(direction.sqrMagnitude != 0) 
        {
            rb.AddForce(direction * speed);
        }
    }

    void MoveInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    void ResetPosition()
    {
        transform.position = rb.position;
        rb.velocity = Vector2.zero;
    }
}
