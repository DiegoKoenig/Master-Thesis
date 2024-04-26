using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private GameController gameController;

    // Die Geschwindigkeit, mit der die Flasche fällt
    private float fallSpeed = 1f;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
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
