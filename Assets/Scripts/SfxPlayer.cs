using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    public static SfxPlayer I;

    public AudioSource src;
    public AudioClip pickUp;
    public AudioClip zap;
    public AudioClip hit;

    void Awake() { I = this; }

    public void PlayPickup() { if (src && pickUp) src.PlayOneShot(pickUp); }
    public void PlayZap() { if (src && zap) src.PlayOneShot(zap); }
    public void PlayHit() { if (src && hit) src.PlayOneShot(hit); }
}
