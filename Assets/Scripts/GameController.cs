using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Canvas GameOverCanvas;
    public Canvas ContinueCanvas;
    public TMP_Text ContinueTimerText;
    public GameObject objectPrefab;
    public GameObject player;
    public AudioSource backgroundMusicSource; // Verwende eine vorhandene AudioSource-Komponente

    public bool isGameOver = false;
    private float continueTime = 10f;
    private bool continueTimerRunning = false;

    private void Awake()
    {
        if (GameOverCanvas != null)
        {
            GameOverCanvas.gameObject.SetActive(false);
        }

        if (ContinueCanvas != null)
        {
            ContinueCanvas.gameObject.SetActive(false);
        }

        StartContinueCountdown();
    }

    void WhenPlayerDies()
    {
        GameOverCanvas.gameObject.SetActive(true);
        StopCountdown();
        HideContinueTimer();

        if (objectPrefab != null)
        {
            Debug.Log("Prefab-Objekt gefunden!");
        }

        if (player != null)
        {
            Destroy(player);
        }

        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop(); // Stoppt die Hintergrundmusik
        }
    }

    void WhenContinueScreenAppears()
    {
        ContinueCanvas.gameObject.SetActive(true);
        StopCountdown();
        HideContinueTimer();

        if (objectPrefab != null)
        {
            Debug.Log("Prefab-Objekt gefunden!");
        }

        if (player != null)
        {
            Destroy(player);
        }

        DestroyFallenObjects(); // Zerstört gefallene Objekte, wenn der Fortsetzungsbildschirm angezeigt wird

        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop(); // Stoppt die Hintergrundmusik
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        isGameOver = true;
        WhenPlayerDies();
    }

    public void EndContinue()
    {
        isGameOver = true;
        WhenContinueScreenAppears();
    }

    public void DestroyFallenObjects()
    {
        GameObject[] fallenObjects = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject obj in fallenObjects)
        {
            Destroy(obj);
        }
    }

    void StartContinueCountdown()
    {
        if (!isGameOver)
        {
            StartCoroutine(ContinueTimer());
        }
    }

    void StopCountdown()
    {
        // Hier kann Code hinzugefügt werden, um den Countdown zu stoppen
        continueTimerRunning = false;
    }

    void HideContinueTimer()
    {
        ContinueTimerText.gameObject.SetActive(false);
    }

    IEnumerator ContinueTimer()
    {
        continueTimerRunning = true;
        float initialTime = 10f;
        continueTime = initialTime;

        while (continueTime > 0 && !isGameOver)
        {
            ContinueTimerText.text = Mathf.RoundToInt(continueTime).ToString();
            yield return new WaitForSeconds(1f);
            continueTime -= 1f;
        }

        if (!isGameOver)
        {
            EndContinue();
        }
    }

    void Start()
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.loop = true;
            backgroundMusicSource.volume = 0.1f; // Lautstärke der Hintergrundmusik
            backgroundMusicSource.Play(); // Startet die Hintergrundmusik
        }
        else
        {
            Debug.LogError("Background music source is not set!");
        }
    }
}
