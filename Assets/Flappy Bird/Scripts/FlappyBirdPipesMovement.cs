using UnityEngine;

public class FlappyBirdPipesMovement : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
