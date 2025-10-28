using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        GameManager.I.AddScore(points);
        AudioManager.I?.PlayPickup();
        Destroy(gameObject);
    }
}
