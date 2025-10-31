using UnityEngine;
using TMPro;

public class WaveController : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText;
    public GameObject wavePanel;
    public TMP_Text waveLabel;

    [Header("Timing")]
    public float waveInterval = 15f;     // time between waves
    public float waveDisplayTime = 2f;   // how long the panel stays visible

    private float elapsed;
    private int wave = 1;
    private bool showingPanel;

    // 🔹 Allows other scripts (like WaveEnemySpawner) to listen for wave start
    public System.Action<int> OnWaveStarted;
    public int CurrentWave => wave;

    void Start()
    {
        if (wavePanel)
            wavePanel.SetActive(false);  // hide "You Win" panel at game start
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (timerText)
            timerText.text = $"Time: {elapsed:0}s";

        // trigger new wave every interval
        if (!showingPanel && elapsed >= wave * waveInterval)
        {
            wave++;
            StartCoroutine(ShowWave());
        }
    }

    System.Collections.IEnumerator ShowWave()
    {
        showingPanel = true;

        // notify listeners (like spawners)
        OnWaveStarted?.Invoke(wave);

        // show panel text
        if (wavePanel)
        {
            wavePanel.SetActive(true);
            if (waveLabel)
                waveLabel.text = $"Wave {wave}";
        }

        // optional flash
        FindFirstObjectByType<ScreenFlash>()?.Flash();

        yield return new WaitForSeconds(waveDisplayTime);

        // hide again
        if (wavePanel)
            wavePanel.SetActive(false);

        showingPanel = false;
    }
}

