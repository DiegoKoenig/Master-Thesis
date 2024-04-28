using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingObject : MonoBehaviour
{
    private GameController gameController;

    private float fallSpeed; // Die Geschwindigkeit, mit der die Flasche fällt

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        // Abrufen der aktuellen Szene und Anpassen der Fallgeschwindigkeit basierend auf der Szene
        fallSpeed = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        // Bewege das Objekt nach unten mit der festgelegten Geschwindigkeit
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (gameController != null)
            {
                gameController.EndGame();
                gameController.DestroyFallenObjects(); // Rufe die Methode zum Zerstören der heruntergefallenen Objekte im GameController auf
            }
        }
        else
        {
            if (!gameController.isGameOver)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
