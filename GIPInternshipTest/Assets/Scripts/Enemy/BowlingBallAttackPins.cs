using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallAttackPins : BowlingBall {

    private GameObject[] pinObjects;
    private Transform pinTransform;

    bool doesPinTransformExist = false;

    bool GetNewPinTarget() {
        pinObjects = GameObject.FindGameObjectsWithTag("BowlingPin");

        for(int currIndex = 0; currIndex < pinObjects.Length; currIndex++) {
            if (pinObjects[currIndex].transform.position.y > transform.position.y) {
                pinTransform = pinObjects[currIndex].transform;
                return true;
            }
        }

        return false;
    }


    protected override void UpdatePosition() {
        if(pinTransform == null) {
            doesPinTransformExist = GetNewPinTarget();
        }

        if (isPathBlocked) {
            velocity = Vector2.zero;
            return;
        }

        if (doesPinTransformExist) {
            velocity = pinTransform.position - transform.position;
        } else {
            velocity = goalTransform.position - transform.position;
        }

        velocity = velocity.normalized * speed;
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }
}
