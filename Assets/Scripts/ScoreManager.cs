using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    private int score = 0; // Punktestand privat machen
    private int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    public int GetScore() // Methode, um auf den Punktestand zuzugreifen
    {
        return score;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " PUNKTE";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " PUNKTE";
        if (highscore < score)
        {
            highscore = score;
            highscoreText.text = "HIGHSCORE: " + highscore.ToString();
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    // Neue Methode zur Aktualisierung des Highscores
    public void UpdateHighScore()
    {
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
}
