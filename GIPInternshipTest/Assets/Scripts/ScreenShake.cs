
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to Main Camera
public class ScreenShake : MonoBehaviour
{

    private bool isShaking = false;

    [SerializeField]
    private float shakeAmt;

    void Update()
    {
        if (isShaking)
        {
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
    }

    public void StartShakingScreen()
    {
        StartCoroutine("ShakeScreen");
    }

    private IEnumerator ShakeScreen()
    {
        Vector3 initPosition = transform.position;

        isShaking = true;

        yield return new WaitForSeconds(.25f);

        isShaking = false;

        transform.position = initPosition;

    }
}