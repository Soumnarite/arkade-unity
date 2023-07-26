using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snake : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Transform segmentPrefab;
    [SerializeField] ParticleSystem foodEffect;

    List<Transform> segments = new List<Transform>();

    Vector2 direction;

    int score;

    void Awake()
    {
        Time.fixedDeltaTime = 0.04f;
    }

    void Start()
    {
        Invoke("ResetGame", 1f);
    }

    void Update()
    {
        MoveInput();
    }

    void FixedUpdate()
    {
        FollowSegments();
        MovePosition();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Snake Wall" || other.tag == "Snake Segment")
        {
            ResetGame();
        }
        else if(other.tag == "Snake Food")
        {
            Grow();
            AddScore();
            foodEffect.Play();
        }
    }

    void MoveInput()
    {
        if(direction.x != 0)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Vector2.up;
            }
            else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Vector2.down;
            }
        }
        else if(direction.y != 0)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
            }
            else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Vector2.right;
            }
        }
    }

    void MovePosition()
    {
        transform.position = new Vector2(Mathf.Round(transform.position.x + direction.x),
                                        Mathf.Round(transform.position.y + direction.y));
    }

    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    void FollowSegments()
    {
        for(int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
    }

    void ResetGame()
    {
        for(int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform);

        transform.position = Vector2.zero;
        direction = Vector2.right;
        score = 0;
        DrawScore();
    }

    void DrawScore()
    {
        scoreText.text = "Score: " + score;
    }

    void AddScore()
    {
        score++;
        DrawScore();
    }
}
