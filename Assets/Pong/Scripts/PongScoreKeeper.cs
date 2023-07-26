using UnityEngine;
using TMPro;

public class PongScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText1;
    [SerializeField] TextMeshProUGUI scoreText2;

    public int score1;
    public int score2;

    void Start()
    {
        ResetScore();
    }

    public void DrawScore1()
    {
        scoreText1.text = score1.ToString();
    }

    public void DrawScore2()
    {
        scoreText2.text = score2.ToString();
    }

    public void AddScore1()
    {
        score1++;
    }

    public void AddScore2()
    {
        score2++;
    }

    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        DrawScore1();
        DrawScore2();
    }
}
