using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 1f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health h = collision.gameObject.GetComponent<Health>();
            if (h != null)
            {
                h.TakeDamage(damage);
            }
        }
    }
}
