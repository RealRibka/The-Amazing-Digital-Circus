using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioSource hoverAudioSource;
    public AudioSource clickAudioSource;
    private bool isMouseOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
        if (!clickAudioSource.isPlaying && !hoverAudioSource.isPlaying)
        {
            hoverAudioSource.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
        hoverAudioSource.Stop();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickAudioSource.Play();
    }

    public void OnTextClicked()
    {
        // Обработка события клика на текст (нужно добавить этот метод в OnClick() событие Text компонента)
        clickAudioSource.Play();
    }
}