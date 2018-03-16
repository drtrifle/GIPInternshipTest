using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallSpawner : MonoBehaviour {
    [SerializeField]
    private float spawnInterval = 10;

    public GameObject[] bowlingBallPrefabs;

    // Use this for initialization
    void Start() {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update() {
        //SpawnBowlingBallOnInput();
    }

    //Raycast from cursor to background and only allow spawn if it hits the polygon collider 
    //For Dev Debug only
    void SpawnBowlingBallOnInput() {
        if (Input.GetButtonDown("Fire2")) {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            cursorPosition.z = 0;

            if (hit.collider != null) {
                cursorPosition.z = 0;
                int rdmIndex = Random.Range(0, bowlingBallPrefabs.Length);
                Instantiate(bowlingBallPrefabs[rdmIndex], cursorPosition, Quaternion.identity);
            }
        }
    }

    #region Coroutines
    private IEnumerator SpawnEnemy() {
        while (!GameManager.isGameOver) {
            Vector3 rdmVector = new Vector3(Random.Range(-11f, 11f), -10f, 0f);
            int rdmIndex = Random.Range(0, bowlingBallPrefabs.Length);
            Instantiate(bowlingBallPrefabs[rdmIndex], rdmVector, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f, 8f));
        }
    }
    #endregion
}
