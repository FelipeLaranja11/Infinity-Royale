using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    [Header("Elixir Drop")]
    public GameObject elixirPrefab;
    public int min = 1;
    public int max = 2;

    [Header("Ability Drop (optional)")]
    public GameObject abilityLootPrefab;   // assign Loot_Ability_Zap
    [Range(0f, 1f)]
    public float abilityDropChance = 0.15f;

    void OnDestroy()
    {
        if (!Application.isPlaying) return;

        // --- elixir drop ---
        if (elixirPrefab)
        {
            int n = Random.Range(min, max + 1);
            for (int i = 0; i < n; i++)
            {
                Vector2 offset = Random.insideUnitCircle * 0.25f;
                Instantiate(elixirPrefab, transform.position + (Vector3)offset, Quaternion.identity);
            }
        }

        // --- ability drop ---
        if (abilityLootPrefab && Random.value < abilityDropChance)
        {
            Instantiate(abilityLootPrefab, transform.position, Quaternion.identity);
        }
    }
}
