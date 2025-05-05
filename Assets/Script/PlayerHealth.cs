using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject restartTextUI;
    public TMP_Text hpText;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (restartTextUI != null)
            restartTextUI.SetActive(false);

        Time.timeScale = 1f;

        UpdateHPText();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        UpdateHPText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
            hpText.text = "HP: " + currentHealth;
    }

    void Die()
    {
        isDead = true;

        if (restartTextUI != null)
            restartTextUI.SetActive(true);

        Time.timeScale = 0f; // หยุดเกม
    }

    void Update()
    {
        // เผื่อยังอยากให้กด R ได้ด้วย
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    // เพิ่มฟังก์ชันสำหรับปุ่ม
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // เปลี่ยนชื่อ scene ให้ตรงกับเมนูของคุณ
    }
}
