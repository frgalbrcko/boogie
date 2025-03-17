using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    public Transform playerTransform; // Odkaz na hráèe
    public float bobbingSpeed = 5f;   // Rychlost kývání
    public float bobbingAmount = 0.05f; // Velikost kývání
    private float timer = 0f;
    private Vector3 startPos;

    public Rigidbody playerRigidbody; // Pøidáme Rigidbody pro ètení rychlosti

    void Start()
    {
        startPos = transform.localPosition; // Uložíme výchozí pozici kamery
    }

    void Update()
    {
        // Získáme rychlost hráèe z Rigidbody
        float playerSpeed = playerRigidbody.velocity.magnitude;

        if (playerSpeed > 0.1f)
        {
            // Pohupování kamery pøi chùzi
            timer += bobbingSpeed * Time.deltaTime * playerSpeed;
            float yOffset = Mathf.Sin(timer) * bobbingAmount;
            transform.localPosition = startPos + new Vector3(0, yOffset, 0);
        }
        else
        {
            // Když hráè stojí, kamera se vrátí do normální polohy
            timer = 0;
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * bobbingSpeed);
        }
    }
}