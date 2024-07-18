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

    public int GetScore()
    {
        return score;
    }

void Start()
{
    // Lädt den gespeicherten Highscore oder setzt ihn auf 0, wenn keiner vorhanden ist
    highscore = PlayerPrefs.GetInt("highscore", 0);
    // Aktualisiert das Score-Textfeld mit dem aktuellen Punktestand
    scoreText.text = score.ToString() + " PUNKTE";
    // Aktualisiert das Highscore-Textfeld mit dem aktuellen Highscore
    highscoreText.text = "HIGHSCORE: " + highscore.ToString();
}

public void AddPoint()
{
    // Erhöht den Punktestand um 1
    score += 1;
    // Aktualisiert das Score-Textfeld mit dem neuen Punktestand
    scoreText.text = score.ToString() + " PUNKTE";
    // Prüft, ob der aktuelle Punktestand den Highscore übertrifft
    if (highscore < score)
    {
        // Setzt den Highscore auf den aktuellen Punktestand
        highscore = score;
        // Aktualisiert das Highscore-Textfeld mit dem neuen Highscore
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        // Speichert den neuen Highscore in den PlayerPrefs
        PlayerPrefs.SetInt("highscore", highscore);
    }
}

public void UpdateHighScore()
{
    // Aktualisiert das Highscore-Textfeld mit dem aktuellen Highscore
    highscoreText.text = "HIGHSCORE: " + highscore.ToString();
}
}
