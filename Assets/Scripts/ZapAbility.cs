using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ZapAbility")]
public class ZapAbility : Ability
{
    public float radius = 3f;
    public float damage = 10f;
    public LayerMask enemyMask;
    public GameObject vfxPrefab;   // <---- add this line

    public override void Execute(GameObject owner)
    {
        var pos = owner.transform.position;
        if (vfxPrefab)
            Object.Instantiate(vfxPrefab, pos, Quaternion.identity);

        var hits = Physics2D.OverlapCircleAll(pos, radius, enemyMask);
        Debug.Log($"ZAP hit {hits.Length} enemies");

        foreach (var h in hits)
        {
            var hp = h.GetComponent<Health>();
            if (hp) hp.TakeDamage(damage);
        }
    }
}
