using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtonManager :  MonoBehaviour
{
    TextMeshProUGUI pongText;
    TextMeshProUGUI snakeText;
    TextMeshProUGUI flappyBirdText;
    TextMeshProUGUI breakoutText;
    TextMeshProUGUI asteroidsText;
    TextMeshProUGUI spaceInvadersText;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
            Time.fixedDeltaTime = 0.01f;
        }
    }

    public void LoadPong()
    {
        SceneManager.LoadScene("Pong");
    }

    public void LoadSnake()
    {
        SceneManager.LoadScene("Snake");
    }

    public void LoadFlappyBird()
    {
        SceneManager.LoadScene("Flappy Bird");
    }

    public void LoadBreakout()
    {
        SceneManager.LoadScene("Breakout");
    }

    public void LoadAsteroids()
    {
        SceneManager.LoadScene("Asteroids");
    }

    public void LoadSpaceInvaders()
    {
        SceneManager.LoadScene("Space Invaders");
    }

    public void LoadCentipede()
    {
        SceneManager.LoadScene("Centipede");
    }

    public void LoadDonkeyKong()
    {
        SceneManager.LoadScene("Donkey Kong");
    }
}
