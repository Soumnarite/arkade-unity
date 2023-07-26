using UnityEngine;

public class SnakeFood : MonoBehaviour
{
    [SerializeField] BoxCollider2D grid;

    void Start()
    {
        GenerateFood();
    }

    void GenerateFood()
    {
        Bounds bounds = grid.bounds;
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        transform.position = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        GenerateFood();
    }
}
