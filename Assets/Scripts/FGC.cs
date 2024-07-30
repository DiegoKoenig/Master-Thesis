using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// FGC = FinalGameController
public class FGC : MonoBehaviour
{
    public bool isGameOver = false;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Speichert beim Sterben während des finalen Levels den aktuellen Punktestands in den PlayerPrefs, passt gegebenfalls den Highscore an und pausiert die Musik
    void WhenPlayerDies()
    {
        ScoreManager.instance.UpdateHighScore();

        PlayerPrefs.SetInt("CurrentScore", ScoreManager.instance.GetScore());

        if (audioManager != null)
        {
            audioManager.PauseMusic();
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        isGameOver = true;
        WhenPlayerDies();
        LoadNextScene();
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Alle erzeugten PET-Flaschen werden zerstört
    public void DestroyFallenObjects()
    {
        GameObject[] fallenObjects = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject obj in fallenObjects)
        {
            Destroy(obj);
        }
    }
}
