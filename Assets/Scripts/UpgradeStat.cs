public enum UpgradeStat
{
    None = 0,

    // Offense
    Damage,
    AttackSpeed,        // lowers fire cooldown / raises fire rate
    ProjectileSpeed,
    ProjectileSize,
    ProjectileCount,
    Pierce,

    // Defense / Utility
    MaxHealth,
    MoveSpeed,
    PickupRange,

    // Meta (elixir-style)
    ElixirCap,
    ElixirRegen,

    // Sensing
    DetectionRadius,
}
