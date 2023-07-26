using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] AsteroidsMeteor meteorPrefab;
    [SerializeField] float spawnRate;
    [SerializeField] int amountPerSpawn;
    [SerializeField] float spawnDistance;
    [Range(0f, 45f)]
    [SerializeField] float trajectoryVariance;

    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    void Spawn()
    {
        for(int i = 0; i < amountPerSpawn; i++)
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;

            spawnPoint += transform.position;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            AsteroidsMeteor meteor = Instantiate(meteorPrefab, spawnPoint, rotation);

            meteor.size = Random.Range(meteor.minSize, meteor.maxSize);

            Vector2 trajectory = rotation * -spawnDirection;
            meteor.AsteroidsMeteorSetTrajectory(trajectory);
        }
    }
}
