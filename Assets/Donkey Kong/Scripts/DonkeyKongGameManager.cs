using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DonkeyKongGameManager : MonoBehaviour
{
    int lives = 3;
    [SerializeField] TextMeshProUGUI livesText;

    int score;
    [SerializeField] TextMeshProUGUI scoreText;

    DonkeyKongMario mario;

    void Awake()
    {
        mario = FindObjectOfType<DonkeyKongMario>();
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }

    public void DonkeyKongProcessLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;

        mario.gameObject.SetActive(false);

        Invoke("RespawnMario", 1);

        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void DonkeyKongWin()
    {
        
    }

    void RespawnMario()
    {
        mario.transform.position = new Vector3(-3.7f, -6.8f, 0);
        mario.gameObject.SetActive(true);
    }

    void GameOver()
    {
        SceneManager.LoadScene("Donkey Kong");
    }
}
