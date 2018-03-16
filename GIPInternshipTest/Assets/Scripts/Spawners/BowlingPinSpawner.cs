using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPinSpawner : MonoBehaviour {

    public GameObject bowlingPinPrefab;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        SpawnBowlingPinOnInput();
    }

    //Raycast from cursor to background and only allow spawn if it hits the polygon collider 
    void SpawnBowlingPinOnInput()
    {
        if (Input.GetButtonDown("Fire1") && !GameManager.isGameOver)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            cursorPosition.z = 0;

            if (hit.collider != null)
            {
                cursorPosition.z = 0;
                Instantiate(bowlingPinPrefab, cursorPosition, Quaternion.identity);
                GameManager.Instance.DamagePlayer(5);
            }
        }
    }
}
