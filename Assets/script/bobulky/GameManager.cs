using UnityEngine;
using TMPro; // Nezapome� na tuto knihovnu pro TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0; // Aktu�ln� sk�re
    public TMP_Text scoreText; // Text pro sk�re
    public ScoreTextEffects scoreTextEffects; // Odkaz na skript pro efekty textu
    public ScoreSoundEffect scoreSoundEffect; // Odkaz na skript pro p�ehr�n� zvuku

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points; // P�id�me sk�re
        UpdateScoreUI(); // Aktualizujeme UI

        // Zavol�me efekt pulzov�n� nebo zhoupnut� textu
        if (scoreTextEffects != null)
        {
            scoreTextEffects.PlayPulseEffect(); // Pulzov�n� textu
            scoreTextEffects.PlayShakeEffect(); // Zhoupnut� textu
        }

        // Zavol�me p�ehr�n� zvuku
        if (scoreSoundEffect != null)
        {
            scoreSoundEffect.PlayScoreSound(); // P�ehr�n� zvuku
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"Score: {score}"; // Aktualizuje text pro sk�re
    }
}