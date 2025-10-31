using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth = 8f;
    public Vector2 minBounds = new(-9.5f, -5f);
    public Vector2 maxBounds = new(9.5f, 5f);

    void LateUpdate()
    {
        if (!target) return;
        var pos = Vector3.Lerp(transform.position, target.position, smooth * Time.deltaTime);
        pos.z = -10f;
        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x);
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);
        transform.position = pos;
    }
}
