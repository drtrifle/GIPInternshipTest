using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthManager))]

//BowlingBall spawns another Bowling Ball Type 
public class BowlingBallSpawnAnotherOnDeath : BowlingBall {

    [SerializeField]
    private BowlingBall spawnBallPrefab;

    #region IDestructible Methods

    public override void Die(int score) {
        SoundManager.Instance.PlayBallKilledSound();

        if (!hasReachedDestination) {
            GameManager.Instance.IncrementPlayerScore(score);
            Instantiate(spawnBallPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
    #endregion
}
