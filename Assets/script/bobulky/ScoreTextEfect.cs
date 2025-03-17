using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreTextEffects : MonoBehaviour
{
    public TMP_Text scoreText; // Text pro sk�re, kter� bude pulzovat nebo se h�bat
    public float pulseDuration = 0.3f; // D�lka pulzace
    public float pulseSize = 1.5f; // Maxim�ln� velikost textu p�i pulzaci
    public float shakeDuration = 0.3f; // D�lka zhoupnut�
    public float shakeMagnitude = 10f; // S�la zhoupnut�

    // Zavol�no pro pulzov�n� textu
    public void PlayPulseEffect()
    {
        StartCoroutine(PulseText());
    }

    // Zavol�no pro zhoupnut� textu
    public void PlayShakeEffect()
    {
        StartCoroutine(ShakeText());
    }

    // Coroutine pro pulzov�n� textu
    private IEnumerator PulseText()
    {
        Vector3 originalScale = scoreText.transform.localScale; // Ulo��me p�vodn� velikost
        Vector3 targetScale = originalScale * pulseSize; // Zv�t�en� velikost textu

        float time = 0f;

        // Zv��en� velikosti
        while (time < pulseDuration)
        {
            time += Time.deltaTime;
            scoreText.transform.localScale = Vector3.Lerp(originalScale, targetScale, time / pulseDuration);
            yield return null;
        }

        // Zp�t na p�vodn� velikost
        time = 0f;
        while (time < pulseDuration)
        {
            time += Time.deltaTime;
            scoreText.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / pulseDuration);
            yield return null;
        }
    }

    // Coroutine pro zhoupnut� textu
    private IEnumerator ShakeText()
    {
        Vector3 originalPosition = scoreText.transform.localPosition; // Ulo��me p�vodn� pozici textu
        float time = 0f;

        // Zhoupnut� textu nahoru a dol�
        while (time < shakeDuration)
        {
            time += Time.deltaTime;
            float shake = Mathf.Sin(time * Mathf.PI * 2f / shakeDuration) * shakeMagnitude;
            scoreText.transform.localPosition = originalPosition + new Vector3(0f, shake, 0f);
            yield return null;
        }

        // Vr�t� text zp�t na p�vodn� pozici
        scoreText.transform.localPosition = originalPosition;
    }
}