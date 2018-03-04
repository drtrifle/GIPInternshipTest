using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public RectTransform mainCanvas;
    public GameObject healthUIPrefab;

    public Vector3 healthUIOffset;

    public HealthBar CreateHealthUI(Transform targetTransform)
    {
        GameObject clone = Instantiate(healthUIPrefab) as GameObject;
        HealthBar healthBar = clone.GetComponent<HealthBar>();
        healthBar.SetHealthBarData(targetTransform, mainCanvas);
        healthBar.transform.SetParent(mainCanvas, false);
        return healthBar;
    }
}
