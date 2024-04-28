using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private float timer = 0f;
    public float delay = 8f; // Zeitverzögerung in Sekunden

    void Update()
    {
        // Den Timer aktualisieren
        timer += Time.deltaTime;

        // Überprüfen, ob die Zeit abgelaufen ist oder der Bildschirm berührt wird
        if (timer >= delay || Input.touchCount > 0)
        {
            // Den Index der aktuellen Szene abrufen
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Überprüfen, ob es eine nächste Szene gibt
            if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                // Zur nächsten Szene wechseln
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            else
            {
                // Wenn keine nächste Szene vorhanden ist, zur ersten Szene zurückkehren
                SceneManager.LoadScene(0);
            }
        }
    }
}
