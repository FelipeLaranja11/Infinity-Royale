using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public AnimationCurve spawnsPerSecond; // x=time(s), y=spawns/sec
    public int maxEnemies = 60;
    public float minDistanceFromPlayer = 6f;

    float t, carry;

    void Update()
    {
        if (!enemyPrefab) return;

        t += Time.deltaTime;
        float sps = spawnsPerSecond.Evaluate(t);
        carry += sps * Time.deltaTime;

        while (carry >= 1f)
        {
            if (Count() >= maxEnemies) break;
            SpawnNearEdges();
            carry -= 1f;
        }
    }

    int Count() => GameObject.FindGameObjectsWithTag("Enemy").Length;

    void SpawnNearEdges()
    {
        var cam = Camera.main;
        float ortho = cam.orthographicSize;
        float halfW = ortho * cam.aspect;

        // pick a random edge
        int edge = Random.Range(0, 4);
        float x = 0, y = 0;
        if (edge == 0) { x = Random.Range(-halfW, halfW); y = ortho; }          // top
        if (edge == 1) { x = Random.Range(-halfW, halfW); y = -ortho; }         // bottom
        if (edge == 2) { x = -halfW; y = Random.Range(-ortho, ortho); }         // left
        if (edge == 3) { x = halfW; y = Random.Range(-ortho, ortho); }         // right

        Vector3 center = cam.transform.position; center.z = 0;
        Vector3 pos = center + new Vector3(x, y, 0);

        // keep a buffer from the player
        var p = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (p && Vector2.Distance(pos, p.position) < minDistanceFromPlayer)
        {
            pos += (pos - p.position).normalized * (minDistanceFromPlayer);
        }

        Instantiate(enemyPrefab, pos, Quaternion.identity);

        var e = Instantiate(enemyPrefab, pos, Quaternion.identity);
        Debug.Log($"Spawned Enemy at {pos}");

    }
}
