using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private float speed = 1f;
    Rigidbody2D projectileRigidbody;
    private float timeBeforeDeactivate = 3f;

    // Use this for initialization
    void Start () {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine("DeactivateAfterTime");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        projectileRigidbody.velocity = transform.right * speed;
    }

    private IEnumerator DeactivateAfterTime()
    {
        yield return new WaitForSeconds(timeBeforeDeactivate);
        gameObject.SetActive(false);
    }
}
