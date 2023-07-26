using UnityEngine;

public class SpaceInvadersSpawner : MonoBehaviour
{
    [SerializeField] SpaceInvadersAlien[] aliens;
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] AnimationCurve speed;
    [SerializeField] SpaceInvadersProjectile missile;
    [SerializeField] float missileAttackRate;

    Vector3 direction = Vector3.right;

    public int spaceInvadersAmountKilled {get; private set;}
    public int spaceInvadersTotalInvaders => rows * columns;
    public float spaceInvadersPercentKilled => (float) spaceInvadersAmountKilled / (float) spaceInvadersTotalInvaders;
    public float spaceInvadersAmountAlive => spaceInvadersTotalInvaders - spaceInvadersAmountKilled;

    void Awake()
    {
        Spawn();
    }

    void Start()
    {
        InvokeRepeating("MissileAttack", missileAttackRate, missileAttackRate);
    }

    void Update()
    {
        transform.position += direction * speed.Evaluate(spaceInvadersPercentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform alien in transform)
        {
            if(!alien.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(direction == Vector3.right && alien.position.x >= rightEdge.x - 2)
            {
                AdvanceRow();
            }
            else if(direction == Vector3.left && alien.position.x <= leftEdge.x + 2)
            {
                AdvanceRow();
            }
        }
    }

    void Spawn()
    {
        for(int row = 0; row < rows; row++)
        {
            float width = 2.0f * (columns - 1);
            float height = 2.0f * (rows - 1);
            Vector2 center = new Vector2(-width / 2, -height / 2);
            Vector3 rowPos = new Vector3(center.x, center.y + row * 2, 0.0f);

            for(int col = 0; col < columns; col++)
            {
                SpaceInvadersAlien alien = Instantiate(aliens[row], transform);
                alien.killed += AlienKilled;
                Vector3 position = rowPos;
                position.x += col * 2;
                alien.transform.localPosition = position;
            }
        }
    }

    void AdvanceRow()
    {
        direction.x *= -1;
        Vector3 pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
    }

    void AlienKilled()
    {
        spaceInvadersAmountKilled++;
    }

    void MissileAttack()
    {
        foreach(Transform alien in transform)
        {
            if(!alien.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(Random.value < (1.0f / (float) spaceInvadersAmountAlive))
            {
                Instantiate(missile, alien.position, Quaternion.identity);
                break;
            }
        }
    }
}
