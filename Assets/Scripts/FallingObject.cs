using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingObject : MonoBehaviour
{
    private GameController gameController;

    private float fallSpeed;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();

        // Abrufen der aktuellen Szene und Anpassen der Fallgeschwindigkeit basierend auf der aktuellen Szenennummer
        fallSpeed = SceneManager.GetActiveScene().buildIndex - 1;
    }

    private void Update()
    {
        // Bewegt das Objekt nach unten mit der festgelegten Geschwindigkeit
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sobald eine fallende PET-Flasche den Boden des Levels berührt, wird das Level beendet und alle aktiven PET-Flaschen zerstört
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (gameController != null)
            {
                gameController.EndGame();
                gameController.DestroyFallenObjects();
            }
        }

        // Bei jeder anderen Berührung (in dieser Version des Spiels nur mit PET-Container möglich) wird lediglich die kollidierende PET-Flasche zerstört
        else
        {
            if (!gameController.isGameOver)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
