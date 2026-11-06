using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level5Manager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public GameObject winPanel;
    public GameObject losePanel;
    public TMP_Text loseMessageText;

    [Header("Settings")]
    public float timeLimit = 60f;
    public int targetScore = 5;

    private float timeLeft;
    public int CurrentScore { get; private set; }
    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        timeLeft = timeLimit;
        CurrentScore = 0;
        UpdateUI();
    }

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString();
            if (timeLeft <= 10f) timerText.color = Color.red;
            else timerText.color = Color.white;
        }

        if (timeLeft <= 0) TriggerLose("Time ran out!");
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        CurrentScore += amount;
        UpdateUI();

        if (CurrentScore >= targetScore)
        {
            // Tell the player they can go to the exit now
            if (timerText != null) timerText.text = "GO TO EXIT!";
            if (timerText != null) timerText.color = Color.green;
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = $"Coins: {CurrentScore} / {targetScore}";
    }

    public void TriggerWin()
    {
        if (isGameOver) return;
        isGameOver = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TriggerLose(string reason)
    {
        if (isGameOver) return;
        isGameOver = true;
        if (loseMessageText != null) loseMessageText.text = reason;
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}