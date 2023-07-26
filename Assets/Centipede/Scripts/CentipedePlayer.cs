using UnityEngine;

public class CentipedePlayer : MonoBehaviour
{
    [SerializeField] float speed;

    Vector2 direction;
    Vector2 spawnPos;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
    }

    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += direction.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }

    public void CentipedeRespawnPlayer()
    {
        transform.position = spawnPos;
        gameObject.SetActive(true);
    }
}
