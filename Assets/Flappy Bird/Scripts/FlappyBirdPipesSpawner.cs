using UnityEngine;

public class FlappyBirdPipesSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipesPrefab;
    [SerializeField] float spawnRate;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;

    void Start()
    {
        InvokeRepeating("SpawnPipes", spawnRate, spawnRate);
    }

    void SpawnPipes()
    {
        Instantiate(pipesPrefab, RandomPosition(), Quaternion.identity);
    }

    Vector3 RandomPosition()
    {
        float yPos = Random.Range(minHeight, maxHeight);
        Vector3 randomPos = new Vector3(10, yPos, 0);
        return randomPos;
    }
}
