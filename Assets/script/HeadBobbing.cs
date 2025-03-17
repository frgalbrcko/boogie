using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    public Transform playerTransform; // Odkaz na hr��e
    public float bobbingSpeed = 5f;   // Rychlost k�v�n�
    public float bobbingAmount = 0.05f; // Velikost k�v�n�
    private float timer = 0f;
    private Vector3 startPos;

    public Rigidbody playerRigidbody; // P�id�me Rigidbody pro �ten� rychlosti

    void Start()
    {
        startPos = transform.localPosition; // Ulo��me v�choz� pozici kamery
    }

    void Update()
    {
        // Z�sk�me rychlost hr��e z Rigidbody
        float playerSpeed = playerRigidbody.velocity.magnitude;

        if (playerSpeed > 0.1f)
        {
            // Pohupov�n� kamery p�i ch�zi
            timer += bobbingSpeed * Time.deltaTime * playerSpeed;
            float yOffset = Mathf.Sin(timer) * bobbingAmount;
            transform.localPosition = startPos + new Vector3(0, yOffset, 0);
        }
        else
        {
            // Kdy� hr�� stoj�, kamera se vr�t� do norm�ln� polohy
            timer = 0;
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * bobbingSpeed);
        }
    }
}