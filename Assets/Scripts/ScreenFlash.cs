using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image overlay;
    public Color color = new Color(1, 0, 0, 0.4f);
    public float duration = 0.2f;

    Color clear; float t;
    void Awake() { clear = new Color(color.r, color.g, color.b, 0); overlay.color = clear; }
    public void Flash() { StopAllCoroutines(); StartCoroutine(F()); }

    System.Collections.IEnumerator F()
    {
        overlay.color = color;
        t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            overlay.color = Color.Lerp(color, clear, t / duration);
            yield return null;
        }
        overlay.color = clear;
    }
}
