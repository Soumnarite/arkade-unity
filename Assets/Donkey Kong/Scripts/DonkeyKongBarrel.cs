using UnityEngine;

public class DonkeyKongBarrel : MonoBehaviour
{
    [SerializeField] float force;

    ParticleSystem explosionEffect;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        explosionEffect = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if(transform.position.y <= -10.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Donkey Kong Platforms")
        {
            rb.AddForce(other.transform.right * force, ForceMode2D.Impulse);
        }

        if(other.gameObject.tag == "Player")
        {
            explosionEffect.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
