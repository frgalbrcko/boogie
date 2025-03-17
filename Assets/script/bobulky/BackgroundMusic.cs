using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource; // Odkaz na AudioSource komponentu
    public AudioClip backgroundMusic; // Zvukov� stopa pro pozad�

    void Start()
    {
        // Nastav�me AudioSource pro p�ehr�v�n� hudby
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic; // P�i�ad�me zvukovou stopu
            audioSource.loop = true; // Nastav�me opakov�n� hudby
            audioSource.Play(); // Spust�me hudbu
        }
    }
}