using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private float speed = 10f;
    Rigidbody2D projectileRigidbody;
    private float timeBeforeDeactivate = 3f;

    // Use this for initialization
    void Start () {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine("DeactivateAfterTime");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        projectileRigidbody.velocity = transform.up * speed;
    }

    public void DeactivateNow()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator DeactivateAfterTime()
    {
        yield return new WaitForSeconds(timeBeforeDeactivate);
        gameObject.SetActive(false);
    }
}
