using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    ScreenShake screenShake;

    void Start()
    {
        screenShake = Camera.main.GetComponent<ScreenShake>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BowlingBall"))
        {
            screenShake.StartShakingScreen();
            other.GetComponent<BowlingBall>().ReachedDestination();
        }
    }
}
