using UnityEngine;

public class Elixir : MonoBehaviour
{
    public int value = 1;                 // XP value
    public float magnetRadius = 4f;       // how close before it starts pulling
    public float pullSpeed = 8f;          // how fast it flies to the player

    Transform player;

    void Update()
    {
        if (!player)
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p) player = p.transform;
            return;
        }

        float d = Vector2.Distance(transform.position, player.position);
        if (d <= magnetRadius)
        {
            transform.position = Vector2.MoveTowards(
                transform.position, player.position, pullSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var lvl = other.GetComponent<LevelSystem>();
            if (lvl) lvl.GainXP(value);
            Destroy(gameObject);
        }
    }
}
