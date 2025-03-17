using UnityEngine;
using TMPro; // Nezapomeò na tuto knihovnu pro TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0; // Aktuální skóre
    public TMP_Text scoreText; // Text pro skóre
    public ScoreTextEffects scoreTextEffects; // Odkaz na skript pro efekty textu
    public ScoreSoundEffect scoreSoundEffect; // Odkaz na skript pro pøehrání zvuku

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
        score += points; // Pøidáme skóre
        UpdateScoreUI(); // Aktualizujeme UI

        // Zavoláme efekt pulzování nebo zhoupnutí textu
        if (scoreTextEffects != null)
        {
            scoreTextEffects.PlayPulseEffect(); // Pulzování textu
            scoreTextEffects.PlayShakeEffect(); // Zhoupnutí textu
        }

        // Zavoláme pøehrání zvuku
        if (scoreSoundEffect != null)
        {
            scoreSoundEffect.PlayScoreSound(); // Pøehrání zvuku
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"Score: {score}"; // Aktualizuje text pro skóre
    }
}