using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            col.collider.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}
