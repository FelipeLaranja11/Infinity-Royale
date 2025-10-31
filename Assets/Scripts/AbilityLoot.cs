using UnityEngine;

public class AbilityLoot : MonoBehaviour
{
    public Ability ability;               // assign (e.g., Zap)
    public float magnetRadius = 4f;
    public float pullSpeed = 8f;

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
            transform.position = Vector2.MoveTowards(transform.position, player.position, pullSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        var loadout = other.GetComponent<AbilityLoadout>();
        if (!loadout) loadout = other.gameObject.AddComponent<AbilityLoadout>();
        if (loadout.AddAbility(ability))
            Destroy(gameObject);
    }
}
