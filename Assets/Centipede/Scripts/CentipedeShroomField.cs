using UnityEngine;
using System.Collections.Generic;

public class CentipedeShroomField : MonoBehaviour
{
    [SerializeField] CentipedeShroom shroomPrefab;
    [SerializeField] int amount;

    BoxCollider2D area;

    List<CentipedeShroom> shrooms;

    void Awake()
    {
        area = GetComponent<BoxCollider2D>();
        shrooms = new List<CentipedeShroom>();
    }

    public void CentipedeGenerateShroomField()
    {
        Bounds bounds = area.bounds;

        for(int i = 0; i < amount; i++)
        {
            Vector2 pos = Vector2.zero;

            pos.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            pos.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

            CentipedeShroom shroom = Instantiate(shroomPrefab, pos, Quaternion.identity, transform);
            shrooms.Add(shroom);
        }
    }

    public void CentipedeClearShroomsField()
    {
        CentipedeShroom[] shrooms = FindObjectsOfType<CentipedeShroom>();

        for(int i = 0; i < shrooms.Length; i++)
        {
            Destroy(shrooms[i].gameObject);
        }
    }

    public void CentipedeHealShroomsField()
    {
        CentipedeShroom[] shrooms = FindObjectsOfType<CentipedeShroom>();

        for(int i = 0; i < shrooms.Length; i++)
        {
            shrooms[i].CentipedeHealShrooms();
        }
    }
}
