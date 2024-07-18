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
        // Initialize the timer
        timer = 0.0f;

        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if it's the initial scene (scene 0)
        isInitialScene = currentSceneIndex == 0;

        // Determine if we should check for touch input or start a timer
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
            // For other scenes, we might want to implement other logic or simply use touch
            shouldCheckTouch = true;
            isAudioClipScene = false;
        }

        // Get the AudioSource component if it's an audio clip scene
        if (isAudioClipScene)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (isInitialScene)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if 3 seconds have passed
            if (timer >= 3.0f)
            {
                // Load the next scene
                LoadNextScene(currentSceneIndex);
            }
        }

        if (shouldCheckTouch)
        {
            // Check if the screen is touched
            if (Input.touchCount > 0)
            {
                // For scenes with audio clips, only proceed if the audio clip has finished playing
                if (isAudioClipScene)
                {
                    if (!audioSource.isPlaying)
                    {
                        // Load the next scene
                        LoadNextScene(currentSceneIndex);
                    }
                }
                else
                {
                    // Load the next scene
                    LoadNextScene(currentSceneIndex);
                }
            }
        }
    }

    private void LoadNextScene(int currentSceneIndex)
    {
        // Check if there is a next scene
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the next scene
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // If no next scene, load the first scene
            SceneManager.LoadScene(0);
        }
    }
}
