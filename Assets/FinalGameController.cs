using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalGameController : MonoBehaviour
{
    public TMP_Text scoreText;
    public Canvas highScoreCanvas;
    public TMP_Text highScoreText;
    public GameObject player;

    private int score = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        if (highScoreCanvas != null)
        {
            highScoreCanvas.gameObject.SetActive(false);
        }
    }

    void WhenPlayerDies()
    {
        if (player != null)
        {
            Destroy(player);
        }
        ShowHighScore();
    }

    public void ObjectCollected()
    {
        score++;
        UpdateScoreText();
    }

    public void ShowHighScore()
    {
        highScoreText.text = "High Score: " + score;
        highScoreCanvas.gameObject.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        isGameOver = true;
        WhenPlayerDies();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && !isGameOver)
        {
            EndGame();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void Start()
    {
        UpdateScoreText();
    }
}
