using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private GUIStyle style = new GUIStyle();
    private GUIStyle boxStyle = new GUIStyle();

    private void Awake()
    {
        style.fontSize = 24;
        style.normal.textColor = Color.white;

        // ��������� ��� �����
        boxStyle.normal.textColor = Color.white;
        boxStyle.fontSize = 18;
    }

    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        // ������ � ������� �����
        Rect boxRect = new Rect(10, 10, 200, 60);

        // ������ ���� � ��������� �������
        GUI.Box(boxRect, "TADC TEST-BUILD", boxStyle);

        // ������� ������ � FPS
        Rect fpsRect = new Rect(10, 50, w, h * 2 / 100);  // Adjusted position
        style.alignment = TextAnchor.UpperLeft;
        float fps = 1.0f / Time.deltaTime;  // Use Time.deltaTime here
        string text = string.Format("{0:0} fps", fps);

        // ������ ����� � FPS
        GUI.Label(fpsRect, text, style);
    }

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }
}