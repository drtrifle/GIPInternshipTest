﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private ObjectPooler objectPooler;

    // Use this for initialization
    void Start () {
        UpdateSpriteRenderer();
        UpdateLocalScale();
        objectPooler = ObjectPooler.Instance;
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

    //Incompltete
    //Need to roatae bullet to face enemy
    void ShootEnemy(Quaternion rotation)
    {
        objectPooler.SpawnFromPool("TowerBullet", transform.position, rotation);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("BowlingBall"))
        {
            Vector3 relativePos = other.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            ShootEnemy(rotation);
        }
    }
}
