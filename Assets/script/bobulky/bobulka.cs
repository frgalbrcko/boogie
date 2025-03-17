using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int scoreValue = 0; // Kolik bod� bobulka p�id�

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Pokud se dotkne hr��
        {
            GameManager.instance.AddScore(scoreValue); // P�id� sk�re
            Destroy(gameObject); // Zni�� bobulku
        }
    }
}