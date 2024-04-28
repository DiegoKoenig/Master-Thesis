using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        // Hole die Button-Komponente des UI-Buttons
        button = GetComponent<Button>();

        // Füge einen Listener hinzu, der die PlaySFX-Methode aufruft, wenn der Button geklickt wird
        button.onClick.AddListener(PlayButtonSound);
    }

    private void PlayButtonSound()
    {
        // Rufe die Methode PlaySFX auf dem AudioManager auf, um die Sound-Datei "TouchNoise" abzuspielen
        AudioManager.Instance.PlaySFX("TouchNoise");
    }
}