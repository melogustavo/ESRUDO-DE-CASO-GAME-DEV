using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;
    private int idx;

    void Update()
    {
        if (points == null || points.Length == 0) return;
        Transform t = points[idx];
        transform.position = Vector3.MoveTowards(transform.position, t.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, t.position) < 0.05f)
            idx = (idx + 1) % points.Length;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.CompareTag("Player")) c.collider.transform.SetParent(transform);
    }
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.collider.CompareTag("Player")) c.collider.transform.SetParent(null);
    }
}
