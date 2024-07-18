using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TMP_Text scoreText;
    private AudioManager audioManager; // Verweis auf den AudioManager
    private float sceneStartTime; // Zeitpunkt, zu dem die Szene gestartet wurde

    void Start()
    {
        // Abrufen des gespeicherten Punktestands aus den PlayerPrefs
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);

        // Anzeigen des Punktestands im Textfeld
        scoreText.text = currentScore.ToString() + " Punkte";

        // Find AudioManager in der Szene
        audioManager = FindObjectOfType<AudioManager>();
        if(audioManager != null)
        {
            audioManager.PlaySFX("CongratulationNoise");
        }
        else
        {
            Debug.LogWarning("AudioManager not found in the scene!");
        }

        // Speichern der Startzeit der Szene
        sceneStartTime = Time.time;
    }

    void Update()
    {
        // Überprüfen, ob seit dem Start der Szene mehr als 5 Sekunden vergangen sind
        if (Time.time - sceneStartTime >= 5f)
        {
            // Überprüfen, ob ein Touch registriert wurde
            if (Input.touchCount > 0)
            {
                // Szene 1 laden
                SceneManager.LoadScene(1);
            }
        }
    }
}
