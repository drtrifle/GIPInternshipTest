using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void UpdateCursorPosition() {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0;
        transform.position = cursorPosition;
    }

    void CheckIfCanSpawnPin() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null) {
            spriteRenderer.sprite = greenCursor;
        } else {
            spriteRenderer.sprite = redCursor;
        }
    }
}
