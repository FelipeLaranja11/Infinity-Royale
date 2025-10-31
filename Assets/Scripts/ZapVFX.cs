using UnityEngine;

public class ZapVFX : MonoBehaviour
{
    public float life = 0.15f;
    public float startScale = 0.2f;
    public float endScale = 3f;
    public SpriteRenderer sr;

    float t;

    void Awake()
    {
        if (!sr) sr = GetComponent<SpriteRenderer>();
        transform.localScale = Vector3.one * startScale;
    }

    void Update()
    {
        t += Time.deltaTime;
        float k = Mathf.Clamp01(t / life);
        float s = Mathf.Lerp(startScale, endScale, k);
        transform.localScale = new Vector3(s, s, 1);
        if (sr) sr.color = new Color(1, 1, 1, 1f - k);
        if (t >= life) Destroy(gameObject);
    }
}
