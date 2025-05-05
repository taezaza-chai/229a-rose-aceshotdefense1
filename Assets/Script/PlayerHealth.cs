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
        Debug.Log("Player HP: " + currentHealth);
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
        Debug.Log("Player Died");

        if (restartTextUI != null)
            restartTextUI.SetActive(true);

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
