using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 1f;
    public float life = 3f;

    private Vector2 dir;

    public void Fire(Vector2 direction) => dir = direction.normalized;

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
        life -= Time.deltaTime;
        if (life <= 0f) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var h = other.GetComponent<Health>();
            if (h) h.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
