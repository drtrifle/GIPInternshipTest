using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPinSpawner : MonoBehaviour {

    public GameObject bowlingPinPrefab;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0;
            Instantiate(bowlingPinPrefab, cursorPosition, Quaternion.identity);
        }
    }
}
