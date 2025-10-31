using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public Health target;          // assign Player's Health here
    public Slider slider;          // assign the HealthBar slider
    public TMP_Text hpText;        // optional

    void Start()
    {
        if (target != null && slider != null)
            slider.maxValue = target.maxHP;
    }

    void Update()
    {
        if (target == null || slider == null) return;

        slider.value = target.CurrentHP;

        if (hpText != null)
            hpText.text = $"HP {Mathf.CeilToInt(target.CurrentHP)}/{Mathf.CeilToInt(target.maxHP)}";
    }
}
