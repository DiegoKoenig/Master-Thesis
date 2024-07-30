using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource;

    bool canMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        // Erst nach 0.1 Sekunden kann der PET-Container bewegt werden
        StartCoroutine(EnableMovement(0.1f));
    }

    IEnumerator EnableMovement(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    void Update()
    {
        // Sobald PET-Container bewegt werden darf, wird Touch-Steuerung ermöglicht
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
        // Falls eine PET-Flasche den PET-Container berührt, wird diese PET-Flasche zerstört und das SFX-Geräusch "PetNoise" abgespielt
        if (canMove && collision.gameObject.CompareTag("Object"))
        {
            Destroy(collision.gameObject);
            AudioManager.Instance.PlaySFX("PetNoise");
        }
    }
}