using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    #region Singleton
    public static SceneLoader Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }
    #endregion

    public void StartGame() {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
