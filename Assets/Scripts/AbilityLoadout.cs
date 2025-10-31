using UnityEngine;
using System.Collections.Generic;

public class AbilityLoadout : MonoBehaviour
{
    // up to 3 active abilities (Q/W/E)
    public List<Ability> slots = new List<Ability>(3); // size 3 in Inspector
    float[] cdTimers = new float[3];

    void Update()
    {
        // tick cooldowns
        for (int i = 0; i < cdTimers.Length; i++)
            if (cdTimers[i] > 0) cdTimers[i] -= Time.deltaTime;

        // Q / W / E triggers
        if (Input.GetKeyDown(KeyCode.Q)) TryUse(0);
        if (Input.GetKeyDown(KeyCode.W)) TryUse(1);
        if (Input.GetKeyDown(KeyCode.E)) TryUse(2);
    }

    void TryUse(int i)
    {
        if (i >= slots.Count) return;
        var a = slots[i];
        if (!a) return;
        if (cdTimers[i] > 0) return;

        a.Execute(gameObject);
        cdTimers[i] = a.cooldown;
        // Debug.Log($"Used {a.abilityName} (slot {i})");
    }

    // called by loot pickup
    public bool AddAbility(Ability ability)
    {
        // already has?
        foreach (var s in slots) if (s == ability) return false;

        // place into first empty slot or replace last if full
        for (int i = 0; i < 3; i++)
        {
            if (i >= slots.Count) slots.Add(null);
            if (slots[i] == null) { slots[i] = ability; return true; }
        }
        // replace last slot (simple policy)
        slots[2] = ability; return true;
    }

    // (optional) expose read-only cooldown for UI
    public float GetCooldown(int i) => (i < cdTimers.Length) ? Mathf.Max(cdTimers[i], 0) : 0f;
}
