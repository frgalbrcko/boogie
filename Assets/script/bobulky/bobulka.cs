using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int scoreValue = 0; // Kolik bodù bobulka pøidá

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Pokud se dotkne hráè
        {
            GameManager.instance.AddScore(scoreValue); // Pøidá skóre
            Destroy(gameObject); // Znièí bobulku
        }
    }
}