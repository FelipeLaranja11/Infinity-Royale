using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP = 10f;
    private float currentHP;

    public float CurrentHP => currentHP;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;

        // trigger flash effect if present
        var flash = GetComponent<HitFlash>();
        if (flash) flash.DoFlash();

        Debug.Log($"{gameObject.name} took {dmg} damage. Remaining HP: {currentHP}");

        if (currentHP <= 0f)
            Die();
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died!");
        Destroy(gameObject);
    }
}
