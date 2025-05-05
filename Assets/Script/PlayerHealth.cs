using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject gameOverUI;
    public TMP_Text hpText;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        Time.timeScale = 1f;
        UpdateHPText();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        UpdateHPText();

        if (currentHealth <= 0)
            Die();
    }

    void UpdateHPText()
    {
        if (hpText != null)
            hpText.text = "HP: " + currentHealth;
    }

    void Die()
    {
        isDead = true;
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // เรียกในปุ่ม Restart
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // เรียกในปุ่ม Main Menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
