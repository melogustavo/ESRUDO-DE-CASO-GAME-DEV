using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth = 6f;

    void LateUpdate()
    {
        if (!target) return;
        Vector3 pos = transform.position;
        pos = Vector3.Lerp(pos, new Vector3(target.position.x, target.position.y, pos.z), Time.deltaTime * smooth);
        transform.position = pos;
    }
}
