using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int remainingHealth;

    public bool isInvincible = false;
    private SpriteRenderer spriteRenderer;
    private bool toggleEnableSprite;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        if (isInvincible)
        {
            //spriteRenderer.enabled = toggleEnableSprite;
            toggleEnableSprite = !toggleEnableSprite;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        }

        remainingHealth -= damage;
        if(remainingHealth <= 0)
        {
            Die();
        }

        StartCoroutine("StartInvincibleSequence");
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator StartInvincibleSequence()
    {
        isInvincible = true;
        yield return new WaitForSecondsRealtime(.5f);
        spriteRenderer.enabled = true;
        isInvincible = false;
    }
}
