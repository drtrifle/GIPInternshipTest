using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        UpdateSpriteRenderer();
        UpdateLocalScale();
    }

    // Update is called once per frame
    void Update () {
        UpdateSpriteRenderer();
        UpdateLocalScale();
    }

    //Order sprites that are closer to the bottom to be rendered last 
    void UpdateSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100f);
    }

    void UpdateLocalScale()
    {
        float yPosition = transform.position.y/10;
        transform.localScale = new Vector3(1- yPosition, 1 - yPosition, 1);
    }
}
