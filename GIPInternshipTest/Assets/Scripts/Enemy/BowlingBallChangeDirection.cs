using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthManager))]
public class BowlingBallChangeDirection : BowlingBall {

    public override void FixedUpdate()
    {
        int rdmInt = Random.Range(0,100);
        if(rdmInt == 0)
        {
            GetDestinationTarget();
        }

        base.FixedUpdate();
    }
}
