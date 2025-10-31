using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public int level = 1;
    public int xp = 0;
    public int xpToNext = 5;
    public Slider xpBar;
    public TMP_Text xpText;
    public GameObject levelUpPanel;
    public Button choiceA, choiceB, choiceC;
    public UpgradeChoice[] possibleChoices;

    void Start()
    {
        UpdateXPUI();
        if (levelUpPanel) levelUpPanel.SetActive(false);
    }

    public void GainXP(int amount)
    {
        xp += amount;
        if (xp >= xpToNext) { LevelUp(); }
        UpdateXPUI();
    }

    void LevelUp()
    {
        level++;
        xp -= xpToNext;
        xpToNext = Mathf.RoundToInt(xpToNext * 1.5f);
        ShowChoices();
    }

    void UpdateXPUI()
    {
        if (xpBar) { xpBar.maxValue = xpToNext; xpBar.value = xp; }
        if (xpText) xpText.text = $"Lvl {level}  ({xp}/{xpToNext})";
    }

    void ShowChoices()
    {
        if (!levelUpPanel || possibleChoices == null || possibleChoices.Length == 0) return;
        levelUpPanel.SetActive(true);
        Time.timeScale = 0f;
        var picks = UpgradeChoice.Random3(possibleChoices);
        SetupButton(choiceA, picks[0]);
        SetupButton(choiceB, picks[1]);
        SetupButton(choiceC, picks[2]);
    }

    void SetupButton(Button btn, UpgradeChoice up)
    {
        if (!btn || up == null) return;
        var label = btn.GetComponentInChildren<TMP_Text>();
        if (label) label.text = up.displayName;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => {
            up.Apply(gameObject);
            if (levelUpPanel) levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
            UpdateXPUI();
        });
    }
}
