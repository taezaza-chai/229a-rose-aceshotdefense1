using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int playerHP = 5;
    public int score = 0;
    public Text hpText;
    public Text scoreText;
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
        gameOverPanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        playerHP -= amount;
        UpdateUI();
        if (playerHP <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        hpText.text = "HP: " + playerHP;
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}