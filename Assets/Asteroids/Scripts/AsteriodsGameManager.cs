using UnityEngine;
using TMPro;

public class AsteriodsGameManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int lives;
    [SerializeField] GameObject lives1;
    [SerializeField] GameObject lives2;
    [SerializeField] GameObject lives3;
    [SerializeField] float respawnTime;
    [SerializeField] float respawnInvulnerabilityTime;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject gameOverUI;

    AsteroidsPlayer player;

    void Awake()
    {
        player = FindObjectOfType<AsteroidsPlayer>();
        gameOverUI.SetActive(false);
    }

    public void AsteroidsProcessPlayerLives()
    {
        explosion.transform.position = player.transform.position;
        explosion.Play();

        ProcessLives();

        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke("Respawn", respawnTime);
        }
    }

    public void AsteroidsMeteorDestroyed(AsteroidsMeteor meteor)
    {
        ProcessScore(10);
        explosion.transform.position = meteor.transform.position;
        explosion.Play();
    }

    void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("Blank");
        player.gameObject.SetActive(true);
        player.canFire = true;
        Invoke("TurnOnCollisions", respawnInvulnerabilityTime);
    }

    void TurnOnCollisions()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Asteroids Player");
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void AsteroidsRestartGame()
    {
        gameOverUI.SetActive(false);
        Respawn();
        lives = 3;
        score = 0;
        scoreText.text = score.ToString();
        LivesGameObjectTrue();
        DestroyAllMeteors();
    }

    void ProcessScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    void ProcessLives()
    {
        lives--;

        if(lives == 3)
        {
            LivesGameObjectTrue();
        }
        else if(lives == 2)
        {
            lives3.SetActive(false);
        }
        else if(lives == 1)
        {
            lives2.SetActive(false);
        }
        else
        {
            LivesGameObjectFalse();
        }
    }

    void LivesGameObjectTrue()
    {
        lives1.SetActive(true);
        lives2.SetActive(true);
        lives3.SetActive(true);
    }

    void LivesGameObjectFalse()
    {
        lives1.SetActive(false);
        lives2.SetActive(false);
        lives3.SetActive(false);
    }

    void DestroyAllMeteors()
    {
        AsteroidsMeteor[] meteors = GameObject.FindObjectsOfType<AsteroidsMeteor>();

        for(int i = 0; i < meteors.Length; i++)
        {
            Destroy(meteors[i].gameObject);
        }
    }
}
