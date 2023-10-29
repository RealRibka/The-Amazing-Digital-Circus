using UnityEngine;
using System.Collections;

public class SettingsAnimation : MonoBehaviour
{

    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.3f);
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
}