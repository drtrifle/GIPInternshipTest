using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private int playerRemainingHealth = 50;

    [SerializeField]
    private int playerScore = 0;
    private int prevScoreThreshold = 10;

    public static bool isGameOver = false;

    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    //Called by BowlingBall
    public void DamagePlayer(int damage)
    {
        playerRemainingHealth -= damage;
        UIManager.Instance.UpdatePlayerHealth(playerRemainingHealth);

        if (playerRemainingHealth <= 0)
        {
            GameOver();
        }
    }

    private void HealPlayer(int healAmt) {
        playerRemainingHealth += 1;
        UIManager.Instance.UpdatePlayerHealth(playerRemainingHealth);
    }

    public void IncrementPlayerScore(int points)
    {
        playerScore += points;
        UIManager.Instance.UpdatePlayerScore(playerScore);

        if(playerScore >= prevScoreThreshold) {
            prevScoreThreshold += 5;
            HealPlayer(1);
        }
    }

    #region Game State Methods
    //Called by Restart Button
    public void RestartGame()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        UIManager.Instance.DisplayGameOverUI();
    }
    #endregion
}
