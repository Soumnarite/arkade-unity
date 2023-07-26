using System.Collections.Generic;
using UnityEngine;

public class CentipedeHead : MonoBehaviour
{
    [SerializeField] CentipedeSegment segmentPrefab;
    [SerializeField] CentipedeShroom shroomPrefab;
    [SerializeField] Sprite headSprite;
    [SerializeField] Sprite segmentSprite;
    [SerializeField] int size;
    [SerializeField] public BoxCollider2D homeArea;
    
    [SerializeField] public float CentipedeSpeed;
    public LayerMask collisionMask;

    List<CentipedeSegment> segments = new List<CentipedeSegment>();

    public void CentipedeRespawn()
    {
        foreach(CentipedeSegment segment in segments)
        {
            Destroy(segment.gameObject);
        }

        segments.Clear();

        for(int i = 0; i < size; i++)
        {
            Vector2 pos = GridPos(transform.position) + (Vector2.left * i);
            CentipedeSegment segment = Instantiate(segmentPrefab, pos, Quaternion.identity, transform);
            segment.centipedeSpriteRenderer.sprite = i == 0 ? headSprite : segmentSprite;
            segment.centipede = this;
            segments.Add(segment);
        }

        for(int i = 0; i < segments.Count; i++)
        {
            CentipedeSegment segment = segments[i];
            segment.ahead = GetSegmentAt(i - 1);
            segment.behind = GetSegmentAt(i + 1);
        }
    }

    public void CentipedeRemove(CentipedeSegment segment)
    {
        Vector3 pos = GridPos(segment.transform.position);
        Instantiate(shroomPrefab, pos, Quaternion.identity);

        if(segment.ahead != null)
        {
            segment.ahead.behind = null;
        }

        if(segment.behind != null)
        {
            segment.behind.ahead = null;
            segment.behind.centipedeSpriteRenderer.sprite = headSprite;
            segment.behind.UpdateHeadSegment();
        }

        segments.Remove(segment);
        Destroy(segment.gameObject);
    }

    Vector2 GridPos(Vector2 pos)
    {
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);
        return pos;
    }

    CentipedeSegment GetSegmentAt(int index)
    {
        if(index >= 0 && index < segments.Count)
        {
            return segments[index];
        }
        else
        {
            return null;
        }
    }
}
