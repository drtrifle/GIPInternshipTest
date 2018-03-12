using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthManager))]
public class BowlingBall : MonoBehaviour {

    private GameObject[] goalObjects;
    private bool isPathBlocked = false;
    public float scaleMutiplier = 1;

    [SerializeField]
    private Transform goalTransform;

    public Vector2 velocity;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private int damage = 1;

    //Component Variables
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private HealthManager healthManager;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        healthManager = GetComponent<HealthManager>();
        GetDestinationTarget();
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

    //Called when Ball has reached goal
    public void ReachedDestination()
    {
        //TODO: Damage player

        //Destroy Ball Object& Healthbar UI 
        healthManager.Die();
    }

    void GetDestinationTarget()
    {
        goalObjects = GameObject.FindGameObjectsWithTag("Goal");
        int rdmIndex = Random.Range(0,goalObjects.Length);
        goalTransform = goalObjects[rdmIndex].transform;
    }

    void UpdateLocalScale()
    {
        float yPosition = transform.position.y / 10;
        transform.localScale = new Vector3((1 - yPosition) * scaleMutiplier, (1 - yPosition) * scaleMutiplier, 1);
    }

    void UpdatePosition()
    {
        if (isPathBlocked)
        {
            velocity = Vector2.zero;
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
