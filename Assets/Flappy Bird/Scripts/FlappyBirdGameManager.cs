using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlappyBirdGameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject playButton;

    FlappyBirdPlayer player;
    FlappyBirdPipesSpawner pipesSpawner;

    int score;

    void Awake()
    {
        player = FindObjectOfType<FlappyBirdPlayer>();
        pipesSpawner = FindObjectOfType<FlappyBirdPipesSpawner>();
        FlappyBirdPause();
    }

    public void FlappyBirdPlay()
    {
        player.FlappyBirdReset();
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        FlappyBirdPipesMovement[] pipes = FindObjectsOfType<FlappyBirdPipesMovement>();

        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void FlappyBirdPause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void FlappyBirdAddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void FlappyBirdGameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        FlappyBirdPause();
    }
}
