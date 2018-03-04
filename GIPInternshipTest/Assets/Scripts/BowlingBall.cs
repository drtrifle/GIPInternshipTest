using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthManager))]
public class BowlingBall : MonoBehaviour {

    public Transform goalTransform;
    private SpriteRenderer spriteRenderer;

    public Vector2 velocity;
    public float speed = 1;

    private Rigidbody2D rb2D;
    private bool isPathBlocked = false;
    private HealthManager healthManager;

    public int damage = 1;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        healthManager = GetComponent<HealthManager>();
        UpdateLocalScale();
        UpdateSpriteRenderer();
    }

    void FixedUpdate()
    {
        UpdatePosition();
        UpdateLocalScale();
        UpdateSpriteRenderer();
        isPathBlocked = false;
    }

    void UpdateLocalScale()
    {
        float yPosition = transform.position.y / 10;
        transform.localScale = new Vector3(1 - yPosition, 1 - yPosition, 1);
    }

    void UpdatePosition()
    {
        if (isPathBlocked)
        {
            return;
        }

        velocity = goalTransform.position - transform.position;
        velocity = velocity.normalized * speed;

        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }

    //Order sprites that are closer to the bottom to be rendered last 
    void UpdateSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100f);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BowlingPin"))
        {
            if (other.transform.position.y >= transform.position.y)
            {
                other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
                isPathBlocked = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("TowerBullet"))
        {
            healthManager.TakeDamage(1);
            other.gameObject.GetComponent<Projectile>().DeactivateNow();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isPathBlocked = false;
    }
}
