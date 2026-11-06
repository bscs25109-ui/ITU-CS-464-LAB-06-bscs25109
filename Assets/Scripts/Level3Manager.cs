using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level3Manager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("Settings")]
    public float timeLimit = 45f;
    public int targetScore = 10;

    private float timeLeft;
    private int currentScore = 0;
    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        timeLeft = timeLimit;
        UpdateUI();
    }

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;

        // Safety check: Only update the text if the slot is not empty
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString();

            if (timeLeft <= 10f) timerText.color = Color.red;
            else timerText.color = Color.white;
        }

        if (timeLeft <= 0)
        {
            TriggerLose();
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        currentScore += amount;
        UpdateUI();

        if (currentScore >= targetScore)
        {
            TriggerWin();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {currentScore} / {targetScore}";
    }

    public void TriggerWin()
    {
        if (isGameOver) return;
        isGameOver = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TriggerLose()
    {
        if (isGameOver) return;
        isGameOver = true;
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}