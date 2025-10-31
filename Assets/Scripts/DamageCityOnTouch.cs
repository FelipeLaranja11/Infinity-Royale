using UnityEngine;

public class DamageCityOnTouch : MonoBehaviour
{
    public float damage = 5f; // per hit

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other) return;
        if (other.CompareTag("City"))
        {
            var hp = other.GetComponent<Health>();
            if (hp) hp.TakeDamage(damage);
            Destroy(gameObject); // enemy consumed on impact
        }
    }
}
