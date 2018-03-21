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
        GameManager.Instance.IncrementPlayerScore(score);
        SoundManager.Instance.PlayBallKilledSound();

        Instantiate(spawnBallPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    #endregion
}
