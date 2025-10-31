using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [Header("UI")]
    public string abilityName = "Ability";
    public Sprite icon;

    [Header("Gameplay")]
    public float cooldown = 3f;

    // called when used
    public abstract void Execute(GameObject owner);
}
