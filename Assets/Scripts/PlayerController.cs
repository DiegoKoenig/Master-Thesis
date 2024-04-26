using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource; // Audiokomponente hinzugefügt

    bool canMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Audiokomponente abgerufen
        StartCoroutine(EnableMovement(0.1f)); // Enable player movement after 0.1 second delay
    }

    IEnumerator EnableMovement(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canMove && collision.gameObject.CompareTag("Object"))
        {
            Destroy(collision.gameObject);
            PlayCollisionSound(); // Funktion zum Abspielen des Kollisions-Sounds aufrufen
        }
    }

    void PlayCollisionSound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Audiokomponente abspielen, wenn vorhanden
        }
    }
}