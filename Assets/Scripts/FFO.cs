using UnityEngine;
using UnityEngine.SceneManagement;

// FFO = FinalFallingObject
public class FFO : MonoBehaviour
{
    private FGC gameController;
    private FallSpeedManager fallSpeedManager;

    private void Start()
    {
        gameController = FindObjectOfType<FGC>();

        // Abrufen der aktuellen Szene und Anpassen der Fallgeschwindigkeit basierend auf der aktuellen Szenennummer
        fallSpeedManager = FallSpeedManager.instance;
    }

    private void Update()
    {
        // Bewegt das Objekt nach unten mit der festgelegten Geschwindigkeit
        transform.Translate(Vector3.down * fallSpeedManager.GetFallSpeed() * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sobald eine fallende PET-Flasche den PET-Container berührt, wird der Punktestand sowie die Fallgeschwindigkeit erhöht und die kollidierende PET-Flasche zerstört
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint();
            fallSpeedManager.IncreaseFallSpeed(0.1f);
            Destroy(gameObject);
        }
        
        // Sobald eine fallende PET-Flasche den Boden des Levels berührt, wird das Level beendet und alle aktiven PET-Flaschen zerstört
        else if (collision.gameObject.CompareTag("Platform"))
        {
            if (gameController != null)
            {
                gameController.EndGame();
                gameController.DestroyFallenObjects();
            }
        }
    }
}
