using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class FFO : MonoBehaviour // Rename the class
{
    private FGC gameController; // Update the reference to FGC

    // The speed at which the object falls
    private float fallSpeed = 1f;

    private void Start()
    {
        gameController = FindObjectOfType<FGC>(); // Update the reference to FGC
        // Abrufen der aktuellen Szene und Anpassen der Fallgeschwindigkeit basierend auf der Szene
        fallSpeed = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        // Move the object down with the set speed
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint();
            Destroy(gameObject);
        }
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