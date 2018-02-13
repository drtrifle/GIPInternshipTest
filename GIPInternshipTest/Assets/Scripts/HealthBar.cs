using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    #region PRIVATE_VARIABLES
    private Vector2 positionCorrection = new Vector2(0, 50);
    private Image healthBarImage;
    #endregion

    #region PUBLIC_REFERENCES
    public RectTransform targetCanvas;
    public RectTransform healthBarMask;
    public Transform objectToFollow; 

    #endregion

    #region PUBLIC_METHODS
    public void SetHealthBarData(Transform targetTransform, RectTransform healthBarPanel)
    {
        this.targetCanvas = healthBarPanel;
        healthBarMask = GetComponent<RectTransform>();
        healthBarImage = healthBarMask.GetChild(0).GetComponent<Image>();
        objectToFollow = targetTransform;
        RepositionHealthBar();
        healthBarMask.gameObject.SetActive(true);
    }

    public void OnHealthChanged(float healthFill)
    {
        healthBarImage.fillAmount = healthFill;
    }

    public void TearDownHealthBar()
    {
        Destroy(gameObject);
    }
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        healthBarMask.GetComponent<Image>().fillAmount = 1f;
    }

    void Update()
    {
        RepositionHealthBar();
    }
    #endregion

    #region PRIVATE_METHODS

    private void RepositionHealthBar()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(objectToFollow.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * targetCanvas.sizeDelta.x) - (targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * targetCanvas.sizeDelta.y) - (targetCanvas.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        healthBarMask.anchoredPosition = WorldObject_ScreenPosition + positionCorrection;
    }
    #endregion
}