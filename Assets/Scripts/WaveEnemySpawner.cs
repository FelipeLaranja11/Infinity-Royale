using UnityEngine;

public class WaveEnemySpawner : MonoBehaviour
{
    [Header("Refs")]
    public WaveController waveController;   // drag from scene
    public Transform player;                // drag Player
    public GameObject enemyPrefab;          // drag Enemy prefab

    [Header("Spawn Settings")]
    public int baseCount = 4;               // wave 1 amount
    public int perWaveIncrease = 2;         // + per wave
    public float spawnRadius = 14f;         // ring around player
    public float minPlayerDistance = 8f;    // don't spawn on top

    [Header("Difficulty Scaling")]
    public float enemyBaseSpeed = 2.2f;     // if prefab doesn't set
    public float speedPerWave = 0.35f;
    public float hpPerWave = 1f;

    void Awake()
    {
        if (!waveController) waveController = FindFirstObjectByType<WaveController>();
        if (!player) player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void OnEnable() { if (waveController) waveController.OnWaveStarted += HandleWave; }
    void OnDisable() { if (waveController) waveController.OnWaveStarted -= HandleWave; }

    void HandleWave(int waveIndex)
    {
        int toSpawn = baseCount + (waveIndex - 1) * perWaveIncrease;
        for (int i = 0; i < toSpawn; i++) SpawnOne(waveIndex);
    }

    void SpawnOne(int waveIndex)
    {
        if (!enemyPrefab || !player) return;

        Vector2 dir = Random.insideUnitCircle.normalized;
        Vector3 pos = player.position + (Vector3)(dir * spawnRadius);

        if (Vector2.Distance(pos, player.position) < minPlayerDistance)
            pos = player.position + (Vector3)(dir * minPlayerDistance);

        var go = Instantiate(enemyPrefab, pos, Quaternion.identity);

        var follow = go.GetComponent<EnemyFollow>();
        if (follow) follow.moveSpeed = enemyBaseSpeed + speedPerWave * (waveIndex - 1);

        var hp = go.GetComponent<Health>();
        if (hp) hp.maxHP += hpPerWave * (waveIndex - 1);
    }
}
