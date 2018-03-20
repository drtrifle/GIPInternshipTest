using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthManager))]
public class BowlingBall : MonoBehaviour, IDestructibleUnit {

    protected GameObject[] goalObjects;
    protected bool isPathBlocked = false;
    [SerializeField]
    private float scaleMutiplier = 1;

    [SerializeField]
    protected Transform goalTransform;

    public Vector2 velocity;
    [SerializeField]
    protected float speed = 1;
    [SerializeField]
    private int damage = 1;

    //Component Variables
    protected Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private HealthManager healthManager;

    public virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        healthManager = GetComponent<HealthManager>();
        goalObjects = GameObject.FindGameObjectsWithTag("Goal");
        GetDestinationTarget();
        UpdateLocalScale();
        UpdateSpriteRenderer();
    }

    public virtual void FixedUpdate()
    {
        UpdatePosition();
        UpdateLocalScale();
        UpdateSpriteRenderer();
        //isPathBlocked = false;
    }

    //Called when Ball has reached goal
    public void ReachedDestination()
    {
        //Damage player
        GameManager.Instance.DamagePlayer(damage);
        //Destroy Ball Object& Healthbar UI 
        healthManager.Die();
    }

    protected void GetDestinationTarget()
    {
        int rdmIndex = Random.Range(0,goalObjects.Length);
        goalTransform = goalObjects[rdmIndex].transform;
    }

    #region UI Methods
    //Order sprites that are closer to the bottom to be rendered last 
    void UpdateSpriteRenderer() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100f);
    }

    void UpdateLocalScale()
    {
        float yPosition = transform.position.y / 10;
        transform.localScale = new Vector3((1 - yPosition) * scaleMutiplier, (1 - yPosition) * scaleMutiplier, 1);
    }
    #endregion

    protected virtual void UpdatePosition() {
        if (isPathBlocked) {
            velocity = Vector2.zero;
            return;
        }

        velocity = goalTransform.position - transform.position;
        velocity = velocity.normalized * speed;

        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }

    #region Collision Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BowlingPin"))
        {
            if (other.transform.position.y >= transform.position.y)
            {
                Debug.Log("OnTriggerEnter2D");

                velocity = Vector2.zero;
                isPathBlocked = true;
                other.gameObject.GetComponentInParent<HealthManager>().TakeDamage(damage);
            }
        }

        if (other.gameObject.CompareTag("TowerBullet"))
        {
            healthManager.TakeDamage(1);
            other.gameObject.GetComponent<Projectile>().DeactivateNow();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BowlingPin"))
        {
            if (other.transform.position.y >= transform.position.y)
            {
                velocity = Vector2.zero;
                isPathBlocked = true;
                other.gameObject.GetComponentInParent<HealthManager>().TakeDamage(damage);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isPathBlocked = false;
    }

    #endregion

    #region IDestructible Methods

    public virtual void Die(int score) {
        GameManager.Instance.IncrementPlayerScore(score);
        SoundManager.Instance.PlayBallKilledSound();

        Destroy(gameObject);
    }
    #endregion
}
