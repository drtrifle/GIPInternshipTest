using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scales Background sprite to fill the current camera area
public class BackgroundSpriteResizer : MonoBehaviour {

    private SpriteRenderer background;

    void Update()
    {
        ResizeSpriteToScreen();
    }

    void ResizeSpriteToScreen()
    {
        background = GetComponent<SpriteRenderer>();
        Debug.Assert(this.background != null);

        transform.localScale = new Vector3(1, 1, 1);

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / background.sprite.bounds.size.x, worldScreenHeight / background.sprite.bounds.size.y, 1);
    }
}
