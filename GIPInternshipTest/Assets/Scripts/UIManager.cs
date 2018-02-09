using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public RectTransform mainCanvas;
    public GameObject healthUIPrefab;

    public Vector3 healthUIOffset;

    public Transform test;

	// Use this for initialization
	void Start () {
        CreateHealthUI(test);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateHealthUI(Transform targetTransform)
    {
        GameObject healthBar = Instantiate(healthUIPrefab) as GameObject;
        healthBar.GetComponent<HealthBar>().SetHealthBarData(targetTransform, mainCanvas);
        healthBar.transform.SetParent(mainCanvas, false);
    }
}
