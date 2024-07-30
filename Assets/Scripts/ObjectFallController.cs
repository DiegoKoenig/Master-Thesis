using System.Collections;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    // Jede Sekunde wird eine fallende PET-Flasche erzeugt
    float wait = 1f;
    public GameObject fallingObject;
    private GameController gameController;

    // Das Erzeugen soll nicht sofort bei Levelbeginn passieren
    bool canSpawn = false;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        StartCoroutine(StartSpawnAfterDelay());
    }

    IEnumerator StartSpawnAfterDelay()
    {
        // Nach 0.5 Sekunden wird das Erzeugen der PET-Flaschen gestartet
        yield return new WaitForSeconds(0.5f);
        canSpawn = true;
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        // Solange das Level nicht beendet ist, werden PET-Flaschen an zufallsgenerierten Punkten des Himmels (oberer Rand des Bildschirms), aber innerhalb einer definierten Range erzeugt 
        while (canSpawn)
        {
            if (!gameController.isGameOver)
            {
                Instantiate(fallingObject, new Vector3(Random.Range(-8, 8), 5, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(wait);
        }
    }

    public void StopSpawning()
    {
        canSpawn = false;

        // Zerstört alle noch vorhandenen herunterfallenden PET-Flaschen
        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject obj in fallingObjects)
        {
            Destroy(obj);
        }
    }
}
