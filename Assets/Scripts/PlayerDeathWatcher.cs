using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathWatcher : MonoBehaviour
{
    public Health playerHealth;        // drag Player's Health
    public GameObject losePanel;       // optional, can reuse WinPanel text

    bool gameOver;

    void Update()
    {
        if (gameOver || playerHealth == null) return;

        if (playerHealth.CurrentHP <= 0f)
        {
            gameOver = true;
            if (losePanel) losePanel.SetActive(true);
            Invoke(nameof(BackToMenu), 2f);
        }
    }

    void BackToMenu() => SceneManager.LoadScene("Menu");
}
