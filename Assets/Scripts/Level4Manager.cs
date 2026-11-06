//using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro;

//public class Level4Manager : MonoBehaviour
//{
//    [Header("UI References")]
//    public TMP_Text timerText;
//    public GameObject winPanel;
//    public GameObject losePanel;

//    [Header("Settings")]
//    public float timeLimit = 45f; // Survive for 45 seconds to win

//    private float timeLeft;
//    private bool isGameOver = false;

//    void Start()
//    {
//        Time.timeScale = 1f; // Unfreeze game just in case
//        winPanel.SetActive(false);
//        losePanel.SetActive(false);
//        timeLeft = timeLimit;
//    }

//    void Update()
//    {
//        if (isGameOver) return;

//        timeLeft -= Time.deltaTime;

//        if (timerText != null)
//        {
//            timerText.text = "Survive: " + Mathf.CeilToInt(timeLeft).ToString();

//            // Change color to green to indicate survival (opposite of Level 2/3)
//            if (timeLeft <= 10f) timerText.color = Color.green;
//            else timerText.color = Color.white;
//        }

//        // If the timer reaches 0, you SURVIVE and WIN!
//        if (timeLeft <= 0)
//        {
//            TriggerWin();
//        }
//    }

//    public void TriggerWin()
//    {
//        if (isGameOver) return;
//        isGameOver = true;
//        winPanel.SetActive(true);
//        Time.timeScale = 0f;
//    }

//    // Kept just in case you fall off the map
//    public void TriggerLose()
//    {
//        if (isGameOver) return;
//        isGameOver = true;
//        losePanel.SetActive(true);
//        Time.timeScale = 0f;
//    }

//    public void RestartLevel()
//    {
//        Time.timeScale = 1f;
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }
//}
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level4Manager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText;
    public GameObject winPanel;
    public GameObject losePanel;
    public TMP_Text loseMessageText; // NEW: To show "Enemy caught you"

    [Header("Settings")]
    public float timeLimit = 45f;

    private float timeLeft;
    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        timeLeft = timeLimit;
    }

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = "Survive: " + Mathf.CeilToInt(timeLeft).ToString();

            if (timeLeft <= 10f) timerText.color = Color.green;
            else timerText.color = Color.white;
        }

        if (timeLeft <= 0)
        {
            TriggerWin();
        }
    }

    public void TriggerWin()
    {
        if (isGameOver) return;
        isGameOver = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Updated to accept a custom reason!
    public void TriggerLose(string reason = "You Died!")
    {
        if (isGameOver) return;
        isGameOver = true;

        if (loseMessageText != null)
        {
            loseMessageText.text = reason;
        }

        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}