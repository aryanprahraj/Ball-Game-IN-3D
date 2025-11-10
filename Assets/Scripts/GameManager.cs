using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text timerText;
    public TMP_Text scoreText;

    [Header("Gameplay Settings")]
    public float timeLeft = 60f;
    private bool gameEnded = false;

    void Start()
    {
        // Resetting cube count every time the game starts
        CubeMatch.matchedCount = 0;
        UpdateScoreText();
    }

    void Update()
    {
        if (gameEnded) return;

        // Updating the timer
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString();

        // Checking for win or loss
        if (CubeMatch.matchedCount >= 4)
        {
            WinGame();
        }
        else if (timeLeft <= 0)
        {
            LoseGame();
        }
    }

    public void UpdateScoreText()
    {
        // Updating the on-screen score (e.g., 2/4)
        scoreText.text = CubeMatch.matchedCount + "/4";
    }

    void WinGame()
    {
        gameEnded = true;
        Debug.Log("WinGame() called — loading WinScreen in 2 seconds...");
        StartCoroutine(LoadWinScreenAfterDelay());
    }

    void LoseGame()
    {
        gameEnded = true;
        Debug.Log("LoseGame() called — loading LoseScreen in 2 seconds...");
        StartCoroutine(LoadLoseScreenAfterDelay());
    }

    IEnumerator LoadWinScreenAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Loading WinScreen...");
        SceneManager.LoadScene("WinScreen");
    }

    IEnumerator LoadLoseScreenAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Loading LoseScreen...");
        SceneManager.LoadScene("LoseScreen");
    }
}
