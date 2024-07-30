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

    public bool isGameOver = false;
    // Level endet nach 20 Sekunden
    private float continueTime = 20f;
    private AudioManager audioManager;

    // Der AudioManager wird zu Beginn eines Levels aufgerufen
    private void Awake()
    {
        audioManager = AudioManager.Instance;

        // Dies ermöglicht das Aufrufen eines GameOver-Bildschirmes und eines Continue-Bildschirmes
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

    // Wenn eine PET-Flasche den Boden berührt, wird der GameOver-Bildschirm aktiviert, der Countdown gestoppt, die Musik pausiert und der PET-Container zerstört.
    void WhenPlayerDies()
    {
        GameOverCanvas.gameObject.SetActive(true);
        StopCountdown();
        HideContinueTimer();
        audioManager.PauseMusic();

        if (player != null)
        {
            Destroy(player);
        }
    }

    // Wenn die 20 Sekunden abgelaufen sind, ohne dass eine PET-Flasche den Boden berührt hat, wird der Continue-Bildschirm aktiviert, der Countdown gestoppt, die Musik pausiert, das SFX-Geräusch "ContinueNoise" abgespielt und der PET-Container zerstört.
    void WhenContinueScreenAppears()
    {
        ContinueCanvas.gameObject.SetActive(true);
        StopCountdown();
        HideContinueTimer();
        audioManager.PauseMusic();
        audioManager.PlaySFX("ContinueNoise");

        if (player != null)
        {
            Destroy(player);
        }

        DestroyFallenObjects(); // Zerstört gefallene Objekte, wenn der Fortsetzungsbildschirm angezeigt wird
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

    void HideContinueTimer()
    {
        ContinueTimerText.gameObject.SetActive(false);
    }

    void StopCountdown()
    {
    }

    // Konfiguriert das Levelende nach 20 Sekunden 
    IEnumerator ContinueTimer()
    {
        float initialTime = 20f;
        continueTime = initialTime;
        while (continueTime > 0 && !isGameOver)
        {
            // Damit während den 20 Sekunden ein Timer in Ganzzahlen herunterzählt
            ContinueTimerText.text = Mathf.RoundToInt(continueTime).ToString();
            yield return new WaitForSeconds(1f);
            continueTime -= 1f;
        }

        if (!isGameOver)
        {
            EndContinue();
        }
    }
}
