using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenSubMenu : MonoBehaviour
{
    // �������, ������� ����� ������� � �����
    [SerializeField]
    private MonoBehaviour[] scriptsToBlock;

    // ���� ������ �������, ������� ����� �������
    [SerializeField]
    private GameObject subMenu;

    private void Update()
    {
        // �� ������ �� ��������� ������������ ��������� � ��������� ����
        if(Input.GetKeyDown(KeyCode.Escape) && !subMenu.activeInHierarchy)
        {
            subMenu.SetActive(true);

            SwitchCursorState(true);

            SetActiveToScripts(false);
        }
    }

    // �������/�������� ��� ������� ���������
    public void SetActiveToScripts(bool status)
    {
        foreach (var script in scriptsToBlock)
        {
            script.enabled = status;
        }
    }

    // ����������� ������� 
    public void SwitchCursorState(bool state)
    {
        switch (state)
        {
            // �������� ������
            case true:
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                break;

            // ��������� ������
            case false:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }
    }
}
