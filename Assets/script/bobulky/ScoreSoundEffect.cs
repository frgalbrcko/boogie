using UnityEngine;

public class ScoreSoundEffect : MonoBehaviour
{
    public AudioSource audioSource; // Komponenta AudioSource, kter� p�ehraje zvuk
    public AudioClip scoreSound; // Zvukov� stopa pro p�ehr�n� p�i p�id�n� sk�re

    // Metoda pro p�ehr�n� zvuku p�i p�id�n� sk�re
    public void PlayScoreSound()
    {
        if (audioSource != null && scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound); // P�ehr�n� zvuku
        }
    }
}