using UnityEngine;

public class DonkeyKongSpawner : MonoBehaviour
{
    [SerializeField] GameObject barrel;
    [SerializeField] float spawnInterval1;
    [SerializeField] float spawnInterval2;

    void Start()
    {
        Invoke("Spawn", spawnInterval1);
    }

    void Spawn()
    {
        float spawnTime = Random.Range(spawnInterval1, spawnInterval2);
        Instantiate(barrel, transform.position, Quaternion.identity);
        Invoke("Spawn", spawnTime);
    }
}
