using UnityEngine;

public class SpaceInvadersProjectile : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] Vector3 direction;

    public System.Action destroyed;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(destroyed != null)
        {
            destroyed.Invoke();
        }

        Destroy(gameObject);
    }
}
