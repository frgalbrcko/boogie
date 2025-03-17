using UnityEngine;

public class ScoreSoundEffect : MonoBehaviour
{
    public AudioSource audioSource; // Komponenta AudioSource, která pøehraje zvuk
    public AudioClip scoreSound; // Zvuková stopa pro pøehrání pøi pøidání skóre

    // Metoda pro pøehrání zvuku pøi pøidání skóre
    public void PlayScoreSound()
    {
        if (audioSource != null && scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound); // Pøehrání zvuku
        }
    }
}