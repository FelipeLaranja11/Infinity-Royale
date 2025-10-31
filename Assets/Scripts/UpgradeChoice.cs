using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Choice", fileName = "U_NewChoice")]
public class UpgradeChoice : ScriptableObject
{
    [Header("UI")]
    public string displayName = "Upgrade";
    [TextArea] public string description;

    [Header("Effect")]
    public UpgradeStat stat = UpgradeStat.None;
    public float amount = 0.5f;     // meaning depends on stat

    public void Apply(GameObject player)
    {
        switch (stat)
        {
            case UpgradeStat.AttackSpeed:
                // we model AttackSpeed as +fire rate (shots/second)
                var aim = player.GetComponent<AutoAim>();
                if (aim) aim.fireRate += amount;
                break;

            case UpgradeStat.Damage:
                // keep a global damage bonus on the player
                var runner = player.GetComponent<AbilityRunner>();
                if (!runner) runner = player.AddComponent<AbilityRunner>();
                runner.GlobalProjectileDamage += amount;
                break;

            case UpgradeStat.MoveSpeed:
                var pc = player.GetComponent<PlayerController>();
                if (pc) pc.moveSpeed += amount;
                break;

            case UpgradeStat.PickupRange:
                var loot = player.GetComponent<LootMagnet>();
                if (!loot) loot = player.gameObject.AddComponent<LootMagnet>();
                loot.extraRadius += amount;
                break;

            case UpgradeStat.MaxHealth:
                var hp = player.GetComponent<Health>();
                if (hp)
                {
                    hp.maxHP += amount;
                    // (optional) also heal the added amount:
                    // expose a setter in Health if you want to refill HP.
                }
                break;

                // add more cases later (ProjectileSpeed, Pierce, etc.)
        }
    }

    // helper to pick 3 distinct items from a pool
    public static UpgradeChoice[] Random3(UpgradeChoice[] pool)
    {
        if (pool == null || pool.Length == 0) return new UpgradeChoice[0];
        if (pool.Length <= 3) return pool;

        UpgradeChoice[] a = new UpgradeChoice[3];
        int i = Random.Range(0, pool.Length);
        int j = (i + Random.Range(1, pool.Length)) % pool.Length;
        int k = (j + Random.Range(1, pool.Length)) % pool.Length;
        a[0] = pool[i]; a[1] = pool[j]; a[2] = pool[k];
        return a;
    }
}
