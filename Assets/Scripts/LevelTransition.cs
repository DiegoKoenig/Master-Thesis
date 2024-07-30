using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private float timer;
    private bool shouldCheckTouch;
    private AudioSource audioSource;
    private bool isAudioClipScene;
    private bool isInitialScene;

    void Start()
    {
        timer = 0.0f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Überprüfet, ob es sich um die Szene 0 (Titelbildschirm) handelt
        isInitialScene = currentSceneIndex == 0;

        // Bestimmt, ob Touch-Eingaben überprüft werden sollen (Übergang zu Level 1 und 4) oder ein Timer gestartet wird (Übergang zu Level 2 und 3, da die Fakten nicht übersprungen werden sollen). In beiden Fällen wird die Hintergrundmusik pausiert.
        if (currentSceneIndex == 2 || currentSceneIndex == 8)
        {
            shouldCheckTouch = true;
            isAudioClipScene = false;
        }
        else if (currentSceneIndex == 4 || currentSceneIndex == 6)
        {
            shouldCheckTouch = true;
            isAudioClipScene = true;
        }
        else
        {
            shouldCheckTouch = true;
            isAudioClipScene = false;
        }

        // Spielt Musik ab, falls es sich um eine Szene mit Audioclips handelt
        if (isAudioClipScene)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Die Szene 0 (Titelbildschirm) soll per Touch-Berührung oder nach 3 Sekunden automatisch verschwinden.
        if (isInitialScene)
        {
            timer += Time.deltaTime;

            // Überprüft, ob 3 Sekunden vergangen sind
            if (timer >= 3.0f)
            {
                LoadNextScene(currentSceneIndex);
            }
        }

        if (shouldCheckTouch)
        {
            // Überprüfen, ob der Bildschirm berührt wird
            if (Input.touchCount > 0)
            {
                // Wenn PET-Fakten vor Level 2 und 3 erzählt werden, kann die neue Szene erst durch Touch-Berührung geladen werden, wenn der Audioclip zu Ende gespielt ist
                if (isAudioClipScene)
                {
                    if (!audioSource.isPlaying)
                    {
                        LoadNextScene(currentSceneIndex);
                    }
                }
                else
                {
                    LoadNextScene(currentSceneIndex);
                }
            }
        }
    }

    private void LoadNextScene(int currentSceneIndex)
    {
        // Überprüft, ob es eine nächste Szene gibt
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // Wenn es keine nächste Szene gibt, wird die erste Szene geladen
            SceneManager.LoadScene(0);
        }
    }
}