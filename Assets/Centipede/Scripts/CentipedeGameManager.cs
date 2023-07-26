using UnityEngine;

public class CentipedeGameManager : MonoBehaviour
{
    public static CentipedeGameManager Instance {get; private set;}
    CentipedePlayer player;
    CentipedeHead centipede;
    CentipedeShroomField shroomField;

    //int score;
    int lives;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy() 
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    void Start()
    {
        player = FindObjectOfType<CentipedePlayer>();
        centipede = FindObjectOfType<CentipedeHead>();
        shroomField = FindObjectOfType<CentipedeShroomField>();

        NewGame();
    }

    void Udpate()
    {
        if(lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    void NewGame()
    {
        //score = 0;
        lives = 3;

        centipede.CentipedeRespawn();
        player.CentipedeRespawnPlayer();
        shroomField.CentipedeClearShroomsField();
        shroomField.CentipedeGenerateShroomField();
    }

    void GameOver()
    {
        player.gameObject.SetActive(false);
    }

    public void CentipedeResetRound()
    {
        lives--;

        if(lives <= 0)
        {
            GameOver();
            return;
        }

        centipede.CentipedeRespawn();
        player.CentipedeRespawnPlayer();
        shroomField.CentipedeHealShroomsField();
    }
}
