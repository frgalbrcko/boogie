using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemyclose : MonoBehaviour
{
    public NavMeshAgent ai;
    public AudioSource footstepsAudio;
    public Transform player;
    public float maxHearingDistance = 15f; // Maxim�ln� vzd�lenost, kde lze sly�et kroky

    void Start()
    {
        // Nastaven� AudioSource jako 3D zvuk
        footstepsAudio.spatialBlend = 1.0f; // Pln� 3D zvuk
        footstepsAudio.rolloffMode = AudioRolloffMode.Linear; // Line�rn� pokles hlasitosti
        footstepsAudio.maxDistance = maxHearingDistance; // Nastav� maxim�ln� dosah zvuku
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (ai.velocity.magnitude > 0.1f)
        {
            if (!footstepsAudio.isPlaying)
            {
                footstepsAudio.Play();
            }

            // Nastaven� hlasitosti podle vzd�lenosti hr��e
            footstepsAudio.volume = Mathf.Clamp(1 - (distance / maxHearingDistance), 0, 1);
        }
        else
        {
            footstepsAudio.Stop();
        }
    }
}