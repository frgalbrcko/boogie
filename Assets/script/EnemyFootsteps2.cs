using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemyclose : MonoBehaviour
{
    public NavMeshAgent ai;
    public AudioSource footstepsAudio;
    public Transform player;
    public float maxHearingDistance = 15f; // Maximální vzdálenost, kde lze slyšet kroky

    void Start()
    {
        // Nastavení AudioSource jako 3D zvuk
        footstepsAudio.spatialBlend = 1.0f; // Plnì 3D zvuk
        footstepsAudio.rolloffMode = AudioRolloffMode.Linear; // Lineární pokles hlasitosti
        footstepsAudio.maxDistance = maxHearingDistance; // Nastaví maximální dosah zvuku
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

            // Nastavení hlasitosti podle vzdálenosti hráèe
            footstepsAudio.volume = Mathf.Clamp(1 - (distance / maxHearingDistance), 0, 1);
        }
        else
        {
            footstepsAudio.Stop();
        }
    }
}