using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float invTime = 1f;

    private int current;
    private float invUntil;
    private SpriteRenderer sr;

    void Awake(){ current = maxHealth; sr = GetComponentInChildren<SpriteRenderer>(); }

    public void TakeDamage(int dmg)
    {
        if (Time.time < invUntil) return;
        current -= dmg;
        invUntil = Time.time + invTime;
        AudioManager.I?.PlayHurt();
        StartCoroutine(Blink());
        if (current <= 0)
        {
            current = maxHealth;
            GameManager.I.LoseLifeAndRespawn(gameObject);
        }
    }

    IEnumerator Blink()
    {
        for (int i=0;i<6;i++)
        {
            if (sr) sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        if (sr) sr.enabled = true;
    }
}
