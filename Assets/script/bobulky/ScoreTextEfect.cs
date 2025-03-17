using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreTextEffects : MonoBehaviour
{
    public TMP_Text scoreText; // Text pro skóre, který bude pulzovat nebo se hýbat
    public float pulseDuration = 0.3f; // Délka pulzace
    public float pulseSize = 1.5f; // Maximální velikost textu pøi pulzaci
    public float shakeDuration = 0.3f; // Délka zhoupnutí
    public float shakeMagnitude = 10f; // Síla zhoupnutí

    // Zavoláno pro pulzování textu
    public void PlayPulseEffect()
    {
        StartCoroutine(PulseText());
    }

    // Zavoláno pro zhoupnutí textu
    public void PlayShakeEffect()
    {
        StartCoroutine(ShakeText());
    }

    // Coroutine pro pulzování textu
    private IEnumerator PulseText()
    {
        Vector3 originalScale = scoreText.transform.localScale; // Uložíme pùvodní velikost
        Vector3 targetScale = originalScale * pulseSize; // Zvìtšená velikost textu

        float time = 0f;

        // Zvýšení velikosti
        while (time < pulseDuration)
        {
            time += Time.deltaTime;
            scoreText.transform.localScale = Vector3.Lerp(originalScale, targetScale, time / pulseDuration);
            yield return null;
        }

        // Zpìt na pùvodní velikost
        time = 0f;
        while (time < pulseDuration)
        {
            time += Time.deltaTime;
            scoreText.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / pulseDuration);
            yield return null;
        }
    }

    // Coroutine pro zhoupnutí textu
    private IEnumerator ShakeText()
    {
        Vector3 originalPosition = scoreText.transform.localPosition; // Uložíme pùvodní pozici textu
        float time = 0f;

        // Zhoupnutí textu nahoru a dolù
        while (time < shakeDuration)
        {
            time += Time.deltaTime;
            float shake = Mathf.Sin(time * Mathf.PI * 2f / shakeDuration) * shakeMagnitude;
            scoreText.transform.localPosition = originalPosition + new Vector3(0f, shake, 0f);
            yield return null;
        }

        // Vrátí text zpìt na pùvodní pozici
        scoreText.transform.localPosition = originalPosition;
    }
}