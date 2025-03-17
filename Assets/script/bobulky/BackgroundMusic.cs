using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource; // Odkaz na AudioSource komponentu
    public AudioClip backgroundMusic; // Zvuková stopa pro pozadí

    void Start()
    {
        // Nastavíme AudioSource pro pøehrávání hudby
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic; // Pøiøadíme zvukovou stopu
            audioSource.loop = true; // Nastavíme opakování hudby
            audioSource.Play(); // Spustíme hudbu
        }
    }
}