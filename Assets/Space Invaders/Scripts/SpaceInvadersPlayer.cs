using UnityEngine;

public class SpaceInvadersPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] SpaceInvadersProjectile laser;

    bool laserActive;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(!laserActive)
        {
            SpaceInvadersProjectile projectile =  Instantiate(laser, transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            laserActive = true;
        }
    }

    void LaserDestroyed()
    {
        laserActive = false;
    }

}
