using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    public float startDelay = 5.0f; // Изменили задержку на 5 секунд
    public float appearDuration = 1.0f;
    public float popHeight = 50.0f;
    public float swayDuration = 2.0f;
    public float swayAmount = 10.0f;

    private RectTransform rectTransform;
    private Vector3 initialScale;
    private float startTime;
    private bool animationStarted = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialScale = rectTransform.localScale;

        // Устанавливаем начальный размер текста как нулевой, чтобы он начался с увеличения
        rectTransform.localScale = Vector3.zero;

        // Запускаем анимацию с задержкой в 5 секунд
        Invoke("StartAnimation", startDelay + 2.0f);
    }

    void StartAnimation()
    {
        // Показываем текст и начинаем анимацию появления с увеличением
        rectTransform.gameObject.SetActive(true);
        startTime = Time.time;
        LeanTween.scale(rectTransform, initialScale, appearDuration)
            .setEase(LeanTweenType.easeOutBack)
            .setOnComplete(() => {
                animationStarted = true;
            });
    }

    void Update()
    {
        if (animationStarted)
        {
            // Покачивание текста
            float sway = Mathf.Sin((Time.time - startTime) * 2 * Mathf.PI / swayDuration) * swayAmount;
            rectTransform.anchoredPosition = new Vector2(initialScale.x, initialScale.y + sway);
        }
    }
}