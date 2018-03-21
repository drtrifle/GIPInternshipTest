using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int initialHealth;
    [SerializeField]
    private int remainingHealth;

    public bool isInvincible = false;
    private SpriteRenderer spriteRenderer;
    private bool toggleEnableSprite;

    //UI Variables
    private UIManager uIManager;
    private HealthBar healthBar;
    private IDestructibleUnit destructibleUnit;

    #region Unity Methods
    private void Awake() {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Use this for initialization
    void Start() {
        remainingHealth = initialHealth;
        SetUpHealthBar();

        spriteRenderer = GetComponent<SpriteRenderer>();
        destructibleUnit = GetComponent<IDestructibleUnit>();
    }

    // Update is called once per frame
    void Update() {
        if (isInvincible) {
            spriteRenderer.enabled = toggleEnableSprite;
            toggleEnableSprite = !toggleEnableSprite;
        }
    }
    #endregion

    public void TakeDamage(int damage) {
        if (isInvincible) {
            return;
        }

        remainingHealth -= damage;
        if (remainingHealth <= 0) {
            Die();
        }

        UpdateHealthUI();

        StartCoroutine("StartInvincibleSequence");
    }

    public virtual void Die() {
        healthBar.TearDownHealthBar();

        destructibleUnit.Die(initialHealth);
    }

    #region Health UI Methods
    void SetUpHealthBar() {
        healthBar = uIManager.CreateHealthBarUI(transform);
    }

    void UpdateHealthUI() {
        healthBar.OnHealthChanged(remainingHealth / (float)initialHealth);
    }
    #endregion

    #region Coroutines
    private IEnumerator StartInvincibleSequence() {
        isInvincible = true;
        yield return new WaitForSecondsRealtime(.5f);
        spriteRenderer.enabled = true;
        isInvincible = false;
    }
    #endregion
}
