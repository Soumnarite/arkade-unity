using UnityEngine;

public class CentipedeSegment : MonoBehaviour
{
    public SpriteRenderer centipedeSpriteRenderer {get; private set;}
    public CentipedeHead centipede {get; set;}
    public CentipedeSegment ahead {get; set;}
    public CentipedeSegment behind {get; set;}
    public bool isHead => ahead == null;

    Vector2 direction = Vector2.right + Vector2.down;
    Vector2 targetPos;

    void Awake()
    {
        centipedeSpriteRenderer = GetComponent<SpriteRenderer>();
        targetPos = transform.position;
    }

    void Update()
    {
        if(isHead && Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            UpdateHeadSegment();
        }

        Vector2 currentPos = transform.position;
        float speed = centipede.CentipedeSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(currentPos, targetPos, speed);

        Vector2 movementDirection = (targetPos - currentPos).normalized;
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Centipede Player"))
        {
            CentipedeGameManager.Instance.CentipedeResetRound();
            return;
        }

        if(other.collider.enabled && other.gameObject.layer == LayerMask.NameToLayer("Centipede Dart"))
        {
            other.collider.enabled = false;
            centipede.CentipedeRemove(this);
        }
    }

    public void UpdateHeadSegment()
    {
        Vector2 gridPos = GridPos(transform.position);
        targetPos = gridPos;
        targetPos.x += direction.x;

        if(Physics2D.OverlapBox(targetPos, Vector2.zero, 0f, centipede.collisionMask))
        {
            direction.x = -direction.x;

            targetPos.x = gridPos.x;
            targetPos.y = gridPos.y + direction.y;

            Bounds homeBounds = centipede.homeArea.bounds;

            if(direction.y == 1f && targetPos.y > homeBounds.max.y || 
            direction.y == -1f && targetPos.y < homeBounds.min.y)
            {
                direction.y = -direction.y;
                targetPos.y = gridPos.y + direction.y;
            }
        }

        if(behind != null)
        {
            behind.UpdateBodySegment();
        }
    }

    void UpdateBodySegment()
    {
        targetPos = GridPos(ahead.transform.position);
        direction = ahead.direction;

        if(behind != null)
        {
            behind.UpdateBodySegment();
        }
    }

    Vector2 GridPos(Vector2 pos)
    {
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);
        return pos;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(targetPos, Vector3.one);
    }
}
