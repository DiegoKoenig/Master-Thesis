using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class FOFC : MonoBehaviour
{
    float wait = 1f;
    public GameObject fallingObject;
    private FGC gameController; // Update the reference to FGC
    
    bool canSpawn = false; // Variable to control object spawning

    void Start()
    {
        gameController = FindObjectOfType<FGC>(); // Update the reference to FGC
        StartCoroutine(StartSpawnAfterDelay());
    }

    IEnumerator StartSpawnAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // Warte eine Sekunde
        canSpawn = true; // Aktiviere das Spawnen
        StartCoroutine(SpawnObjects()); // Starte das Spawnen von Objekten
    }

    IEnumerator SpawnObjects()
    {
        while (canSpawn)
        {
            if (!gameController.isGameOver) // Check if the game is over
            {
                Instantiate(fallingObject, new Vector3(Random.Range(-8, 8), 5, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(wait);
        }
    }

    // Method to stop spawning objects
    public void StopSpawning()
    {
        canSpawn = false;
    }
}