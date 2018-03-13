﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private int playerRemainingHealth = 50;

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

    private void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
    }

    //Called by Restart Button
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
