using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    float wait = 1f;
    public GameObject fallingObject;
    private GameController gameController;

    bool canSpawn = true; // Variable, um das Spawnen von Objekten zu steuern

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (canSpawn)
        {
            if (!gameController.isGameOver) // Überprüfe, ob das Spiel endet
            {
                Instantiate(fallingObject, new Vector3(Random.Range(-5, 5), 5, 0), Quaternion.identity);
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
