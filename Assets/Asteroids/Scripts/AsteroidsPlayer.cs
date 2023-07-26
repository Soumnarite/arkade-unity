using System.Collections;
using UnityEngine;

public class AsteroidsPlayer : MonoBehaviour
{
    [SerializeField] float forwardSpeed;
    bool forward;

    [SerializeField] float rotationSpeed;
    float direction;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float fireRate;
    public bool canFire = true;

    Rigidbody2D rb;
    AsteriodsGameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<AsteriodsGameManager>();
    }

    void Update()
    {
        MoveInput();
    }

    void FixedUpdate() 
    {
        MovePosition();

        if(Input.GetKey(KeyCode.Space) && canFire)
        {
            StartCoroutine("Shoot");
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0.0f;
        gameObject.SetActive(false);

        gameManager.AsteroidsProcessPlayerLives();
    }

    void MoveInput()
    {
        forward = Input.GetKey(KeyCode.W);

        if(Input.GetKey(KeyCode.A))
        {
            direction = 1f;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            direction = -1f;
        }
        else
        {
            direction = 0;
        }
    }

    void MovePosition()
    {
        if(forward)
        {
            rb.AddForce(transform.up * forwardSpeed);
        }

        if(direction != 0)
        {
            rb.AddTorque(direction * rotationSpeed);
        }
    }

    IEnumerator Shoot()
    {
        canFire = false;
        SpawnBullet();
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    void SpawnBullet()
    {
        Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation);
    }
}
