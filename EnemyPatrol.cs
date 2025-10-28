using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;
    public float waitAtPoint = 0.5f;

    private int idx;
    private float waitUntil;
    private SpriteRenderer sr;

    void Awake(){ sr = GetComponentInChildren<SpriteRenderer>(); }

    void Update()
    {
        if (points == null || points.Length == 0) return;
        if (Time.time < waitUntil) return;
        Transform target = points[idx];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (sr) sr.flipX = (target.position.x - transform.position.x) < 0f;
        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            idx = (idx + 1) % points.Length;
            waitUntil = Time.time + waitAtPoint;
        }
    }
}
