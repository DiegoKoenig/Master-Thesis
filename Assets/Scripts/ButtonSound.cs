using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        // Fügt einen Listener hinzu, der die PlaySFX-Methode aufruft, wenn ein Button geklickt wird
        button.onClick.AddListener(PlayButtonSound);
    }

    private void PlayButtonSound()
    {
        // Ruft die Methode PlaySFX des AudioManagers auf, um die Sound-Datei "TouchNoise" abzuspielen
        AudioManager.Instance.PlaySFX("TouchNoise");
    }
}