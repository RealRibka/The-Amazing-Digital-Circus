using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text textComponent;
    private Color originalColor;
    private Color hoverColor = Color.red; // Можете изменить цвет на свой выбор
    private Vector3 originalScale;
    private Vector3 hoverScale = new Vector3(0.8f, 0.8f, 1f); // Можете изменить значения размера на свой выбор

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        originalColor = textComponent.color;
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textComponent.color = hoverColor;
        transform.localScale = hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textComponent.color = originalColor;
        transform.localScale = originalScale;
    }
}