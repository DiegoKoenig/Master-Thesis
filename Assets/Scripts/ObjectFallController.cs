using System.Collections;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    float wait = 1f;
    public GameObject fallingObject;
    private GameController gameController;

    bool canSpawn = false; // Starte das Spawnen nicht sofort

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        StartCoroutine(StartSpawnAfterDelay()); // Starte die Coroutine zum Warten und dann zum Spawnen
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
            if (!gameController.isGameOver) // Überprüfe, ob das Spiel endet
            {
                Instantiate(fallingObject, new Vector3(Random.Range(-8, 8), 5, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(wait);
        }
    }

    // Methode zum Stoppen des Spawnens von Objekten
    public void StopSpawning()
    {
        canSpawn = false;
        // Zerstört alle noch vorhandenen herunterfallenden Objekte
        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject obj in fallingObjects)
        {
            Destroy(obj);
        }
    }
}
