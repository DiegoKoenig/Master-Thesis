using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TMP_Text scoreText;
    private AudioManager audioManager;
    private float sceneStartTime;

    void Start()
    {
        // Ruft den gespeicherten Punktestand aus den PlayerPrefs ab
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);

        // Zeigt den Punktestand im Textfeld an
        scoreText.text = currentScore.ToString() + " Punkte";

        // Spielt die Audio-Datei "CongratulationNoise" ab
        audioManager = FindObjectOfType<AudioManager>();
        if(audioManager != null)
        {
            audioManager.PlaySFX("CongratulationNoise");
        }

        // Speichert die Startzeit der Szene
        sceneStartTime = Time.time;
    }

    void Update()
    {
        // Überprüft, ob seit dem Start der Szene mehr als 5 Sekunden vergangen sind
        if (Time.time - sceneStartTime >= 5f)
        {
            // Überprüft, ob ein Touch registriert wurde
            if (Input.touchCount > 0)
            {
                // Falls einen der beiden Fälle eintrifft, wird Szene 1 und somit das Hauptmenü geladen
                SceneManager.LoadScene(1);
            }
        }
    }
}