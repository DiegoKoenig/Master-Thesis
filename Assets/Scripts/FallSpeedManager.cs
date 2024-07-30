using UnityEngine;
using UnityEngine.SceneManagement;

public class FallSpeedManager : MonoBehaviour
{
    public static FallSpeedManager instance;
    private float fallSpeed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        fallSpeed = SceneManager.GetActiveScene().buildIndex - 1;
    }

    public float GetFallSpeed()
    {
        return fallSpeed;
    }

    public void IncreaseFallSpeed(float increment)
    {
        fallSpeed += increment;
        Debug.Log("New Fall Speed: " + fallSpeed);
    }
}