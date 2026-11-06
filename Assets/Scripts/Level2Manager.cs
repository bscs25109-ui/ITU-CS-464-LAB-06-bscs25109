using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level2Manager : MonoBehaviour
{
    [Header("UI to Connect")]
    public TMP_Text timerText;
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("Settings")]
    public float timeLimit = 60f;

    private float timeLeft;
    private bool isGameOver = false;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        timeLeft = timeLimit;
    }

    void Update()
    {
        // If we already won or lost, stop the timer
        if (isGameOver) return;

        // Count down
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString();

        // Turn text red when close to losing
        if (timeLeft <= 10f) timerText.color = Color.red;
        else timerText.color = Color.white;

        // Time ran out! You lose.
        if (timeLeft <= 0)
        {
            TriggerLose();
        }
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