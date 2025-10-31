using UnityEngine;

public class HitFlash : MonoBehaviour
{
    public SpriteRenderer sr;          // sprite to flash
    public Color flash = Color.white;  // flash color
    public float time = 0.05f;         // how long the flash lasts
    Color original;

    void Awake()
    {
        if (!sr) sr = GetComponent<SpriteRenderer>();
        original = sr.color;
    }

    public void DoFlash()
    {
        StopAllCoroutines();
        StartCoroutine(C());
    }

    System.Collections.IEnumerator C()
    {
        sr.color = flash;
        yield return new WaitForSeconds(time);
        sr.color = original;
    }
}
