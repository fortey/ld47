using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform healthBar;
    public Transform objectToFollow;
    public RectTransform targetCanvas;
    public Image HealthLine;
    public float offsetY = 30;

    void Update()
    {
        RepositionHealthBar();
    }
    private void RepositionHealthBar()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(objectToFollow.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * targetCanvas.sizeDelta.x) - (targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * targetCanvas.sizeDelta.y) - (targetCanvas.sizeDelta.y * 0.5f)) + offsetY);
        //now you can set the position of the ui element
        healthBar.anchoredPosition = WorldObject_ScreenPosition;
    }

    public void OnHealthChanged(float healthFill)
    {
        HealthLine.fillAmount = healthFill;
    }
}
