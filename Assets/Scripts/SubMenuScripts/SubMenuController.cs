using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenSubMenu : MonoBehaviour
{
    // Скрипты, которые нужно оффнуть у перса
    [SerializeField]
    private MonoBehaviour[] scriptsToBlock;

    // сама ебаная менюшка, которую нужно открыть
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
            case true:
                // Прекрепляем курсор к середине экрана
                Cursor.lockState = CursorLockMode.Confined;
                // и делаем его невидимым
                Cursor.visible = true;
                break;

            case false:
                // Прекрепляем курсор к середине экрана
                Cursor.lockState = CursorLockMode.Locked;
                // и делаем его невидимым
                Cursor.visible = false;
                break;
        }
    }
}
