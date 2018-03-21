using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages game state and player information
public class GameManager : MonoBehaviour {

    public static int playerRemainingHealth = 50;

    public static int playerScore = 0;
    private int prevScoreThreshold = 10;

    public static bool isGameOver = false;

    public static GameObject[] goalObjects;

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

    #region Unity Methods
    private void Start() {
        goalObjects = GameObject.FindGameObjectsWithTag("Goal");
    }
    #endregion

    #region Player Methods

    //Damages player & updates UI
    public void DamagePlayer(int damage) {
        playerRemainingHealth -= damage;
        UIManager.Instance.UpdatePlayerHealth(playerRemainingHealth);

        if (playerRemainingHealth <= 0) {
            GameOver();
        }
    }

    //Heals player and updates UI
    private void HealPlayer(int healAmt) {
        playerRemainingHealth += 1;
        UIManager.Instance.UpdatePlayerHealth(playerRemainingHealth);
    }

    //Increments player score & updates UI
    public void IncrementPlayerScore(int points) {
        playerScore += points;
        UIManager.Instance.UpdatePlayerScore(playerScore);

        if (playerScore >= prevScoreThreshold) {
            prevScoreThreshold += 5;
            HealPlayer(1);
        }
    }
    #endregion

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

    //Returns a random goal transform from array of goal transforms
    public Transform GetRandomGoalDestination() {
        int rdmIndex = Random.Range(0, goalObjects.Length);
        return goalObjects[rdmIndex].transform;
    }
}
