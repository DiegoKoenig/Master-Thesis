using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FGC : MonoBehaviour
{
    public bool isGameOver = false;
    private AudioManager audioManager; // Referenz auf den AudioManager

    private void Start()
    {
        // AudioManager finden und Referenz speichern
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene!");
        }
    }

    void WhenPlayerDies()
    {
        ScoreManager.instance.UpdateHighScore();

        // Speichern des aktuellen Punktestands in den PlayerPrefs
        PlayerPrefs.SetInt("CurrentScore", ScoreManager.instance.GetScore());

        if (audioManager != null)
        {
            audioManager.PauseMusic(); // Musik pausieren
        }
        else
        {
            Debug.LogError("AudioManager reference is null!");
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
        LoadNextScene(); // Aufruf der Methode LoadNextScene, um die nächste Szene zu laden
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void DestroyFallenObjects()
    {
        GameObject[] fallenObjects = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject obj in fallenObjects)
        {
            Destroy(obj);
        }
    }
}
