using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Causes the gameobject to follow the mouse cursor
public class CursorManager : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite greenCursor;
    [SerializeField]
    Sprite redCursor;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        CheckIfCanSpawnPin();
        UpdateCursorPosition();
    }

    //Makes the CursorObject Follow the mouse cursor
    void UpdateCursorPosition() {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0;
        transform.position = cursorPosition;
    }

    //Changes Cursor Colour depending on if player can spawn pins there or not
    void CheckIfCanSpawnPin() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && GameManager.playerRemainingHealth > 5) {
            spriteRenderer.sprite = greenCursor;
        } else {
            spriteRenderer.sprite = redCursor;
        }
    }
}
