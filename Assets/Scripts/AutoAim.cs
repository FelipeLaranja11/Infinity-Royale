using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public GameObject projectilePrefab;  // <-- this creates the "Projectile Prefab" slot
    public float fireRate = 2f;          // "Fire Rate"
    public float detectionRadius = 10f;  // "Detection Radius"
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 1f / fireRate) return;

        Transform target = FindClosestEnemy();
        if (target == null) return;

        Vector2 dir = (target.position - transform.position).normalized;
        GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        go.GetComponent<Projectile>().Fire(dir);
        timer = 0f;
    }

    Transform FindClosestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        Transform closest = null;
        float best = Mathf.Infinity;
        foreach (var h in hits)
        {
            if (h.CompareTag("Enemy"))
            {
                float d = (h.transform.position - transform.position).sqrMagnitude;
                if (d < best) { best = d; closest = h.transform; }
            }
        }
        return closest;
    }
}
