using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    public RectTransform mainCanvas;
    public GameObject healthUIPrefab;

    public Vector3 healthUIOffset;
    public Text playerHealthText;
    public Text playerScoreText;
    public GameObject gameOverUI;

    #region Singleton
    public static UIManager Instance;

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

    public void UpdatePlayerHealth(int playerRemainingHealth)
    {
        if(playerRemainingHealth < 0)
        {
            playerRemainingHealth = 0;
        }

        playerHealthText.text = "Health: " + playerRemainingHealth;
    }

    public void UpdatePlayerScore(int playerCurrentScore)
    {
        playerScoreText.text = "Score: " + playerCurrentScore;
    }

    public HealthBar CreateHealthBarUI(Transform targetTransform)
    {
        GameObject clone = Instantiate(healthUIPrefab) as GameObject;
        HealthBar healthBar = clone.GetComponent<HealthBar>();
        healthBar.SetHealthBarData(targetTransform, mainCanvas);
        healthBar.transform.SetParent(mainCanvas, false);
        return healthBar;
    }

    public void DisplayGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
}
