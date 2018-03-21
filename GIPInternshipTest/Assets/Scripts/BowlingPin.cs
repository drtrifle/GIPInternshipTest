using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour, IDestructibleUnit {

    private SpriteRenderer spriteRenderer;
    private ObjectPooler objectPooler;
    private float shootingInterval = 0.5f;
    private Dictionary<GameObject, bool> pinDictionary;

    private bool isShooting = false;

    #region Unity Methods
    // Use this for initialization
    void Start() {
        UpdateSpriteRenderer();
        UpdateLocalScale();
        objectPooler = ObjectPooler.Instance;
        pinDictionary = new Dictionary<GameObject, bool>();
    }

    // Update is called once per frame
    void Update() {
        UpdateSpriteRenderer();
        UpdateLocalScale();
    }
    #endregion

    #region UI Methods
    //Order sprites that are closer to the bottom to be rendered last 
    void UpdateSpriteRenderer() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100f);
    }

    void UpdateLocalScale() {
        float yPosition = transform.position.y / 10;
        transform.localScale = new Vector3(1 - yPosition, 1 - yPosition, 1);
    }
    #endregion

    #region Collision Methods
    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("BowlingBall")) {
            if (!pinDictionary.ContainsKey(other.gameObject)) {
                pinDictionary.Add(other.gameObject, true);
            }

            if (!isShooting) {
                StartCoroutine(ShootBullets(other.gameObject));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("BowlingBall")) {
            //Exit Prematurelly if object not in dictionary
            if (!pinDictionary.ContainsKey(other.gameObject)) {
                Debug.LogWarning("Pin GameObject does not exist in Dictionary!");
                return;
            }

            pinDictionary[other.gameObject] = false;
        }
    }
    #endregion

    #region Coroutines
    //Coroutine that continously shoots at enemy 
    private IEnumerator ShootBullets(GameObject target) {
        //Exit Prematurely if object not in dictionary or already shooting
        if (!pinDictionary.ContainsKey(target) || isShooting) {
            //Debug.LogWarning("Pin GameObject does not exist in Dictionary!");
            yield break;
        }

        isShooting = true;

        while (pinDictionary[target]) {
            yield return new WaitForSeconds(shootingInterval);

            //Break early if target was destroyed
            if (target == null) {
                isShooting = false;
                yield break;
            }

            //calculates the angle the bullet prefab must be rotated to face the enemy
            float XDif = target.transform.position.x - transform.position.x;
            float YDif = target.transform.position.y - transform.position.y;

            float angle = Vector2.Angle(new Vector2(XDif, YDif), new Vector2(0, 1));

            //flips the sign of the angle determining on player position relative to the enemy current posisiton
            if (XDif >= 0) {
                angle = -angle;
            }

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            ShootEnemy(rotation);
        }


        //Remove Gameobject from Dictionary
        pinDictionary.Remove(target);
        isShooting = false;
    }
    #endregion

    #region IDestructible Methods
    public void Die(int score) {
        Destroy(gameObject);
    }
    #endregion

    #region Attack Methods
    //Takes in a rotation which will be the bullet's rotation on spawn
    void ShootEnemy(Quaternion rotation) {
        SoundManager.Instance.PlayBulletSound();
        objectPooler.SpawnFromPool("TowerBullet", transform.position, rotation);
    }
    #endregion
}
