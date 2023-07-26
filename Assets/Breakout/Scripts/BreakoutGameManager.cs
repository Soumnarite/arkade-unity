using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreakoutGameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    int lives = 3;
    int score = 0;

    BreakoutPlayer player;
    BreakoutBall ball;
    BreakoutBrick[] bricks;

    void Awake()
    {
        player = FindObjectOfType<BreakoutPlayer>();
        ball = FindObjectOfType<BreakoutBall>();
        bricks = FindObjectsOfType<BreakoutBrick>();
    }

    public void BreakoutCheckLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;

        if(lives > 0)
        {
            ball.BreakoutResetBall();
        }
        else if(lives == 0)
        {
            NewGame();
        }
    }

    public void BreakoutAddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    void NewGame()
    {
        ball.BreakoutResetBall();
        player.BreakoutResetPaddle();
        lives = 3;
        livesText.text = "Lives: " + lives;
        score = 0;
        scoreText.text = "Score: " + score;

        for(int i = 0; i < bricks.Length; i++)
        {
            bricks[i].BreakoutResetBricks();
        }
    }
}
