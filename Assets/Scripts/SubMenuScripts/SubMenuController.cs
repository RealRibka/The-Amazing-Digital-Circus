using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenSubMenu : MonoBehaviour
{
    // Скрипты, которые нужно оффнуть у перса
    [SerializeField]
    private MonoBehaviour[] scriptsToBlock;

    // Сама ебаная менюшка, которую нужно открыть
    [SerializeField]
    private GameObject subMenu;

    private void Update()
    {
        // На эскейп мы отключаем передвижение персонажа и открываем меню
        if(Input.GetKeyDown(KeyCode.Escape) && !subMenu.activeInHierarchy)
        {
            subMenu.SetActive(true);

            SwitchCursorState(true);

            SetActiveToScripts(false);
        }
    }

    // Врубаем/отрубаем все скрипты персонажа
    public void SetActiveToScripts(bool status)
    {
        foreach (var script in scriptsToBlock)
        {
            script.enabled = status;
        }
    }

    // Отображения курсора 
    public void SwitchCursorState(bool state)
    {
        switch (state)
        {
            // Включаем курсор
            case true:
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                break;

            // Выключаем курсор
            case false:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }
    }
}
