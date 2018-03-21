using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns BowlingPin Objects on Left Click
public class BowlingPinSpawner : MonoBehaviour {

    public GameObject bowlingPinPrefab;

    // Update is called once per frame
    void Update()
    {
        SpawnBowlingPinOnInput();
    }

    //Raycast from cursor to background and only allow spawn if it hits the background polygon collider & if player has more than 5 health
    void SpawnBowlingPinOnInput()
    {
        if (GameManager.Instance.playerRemainingHealth > 5 && Input.GetButtonDown("Fire1") && !GameManager.Instance.isGameOver)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            cursorPosition.z = 0;

            if (hit.collider != null)
            {
                cursorPosition.z = 0;
                Instantiate(bowlingPinPrefab, cursorPosition, Quaternion.identity);
                GameManager.Instance.DamagePlayer(5);
                SoundManager.Instance.PlayPlacePinSound();
            }
        }
    }
}
