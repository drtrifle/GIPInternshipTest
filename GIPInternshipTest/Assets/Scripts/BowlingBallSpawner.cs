using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallSpawner : MonoBehaviour
{

    public GameObject bowlingBallPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawnBowlingBallOnInput();
    }

    //Raycast from cursor to background and only allow spawn if it hits the polygon collider 
    void SpawnBowlingBallOnInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            cursorPosition.z = 0;

            if (hit.collider != null)
            {
                cursorPosition.z = 0;
                Instantiate(bowlingBallPrefab, cursorPosition, Quaternion.identity);
            }
        }
    }
}
