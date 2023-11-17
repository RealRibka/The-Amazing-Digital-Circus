using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtonSubMenu : MonoBehaviour
{
    // ����� ������� ���������� �� ������ ������� ��� �����
    [SerializeField]
    private GameObject subMenu;

    // ����� ������� �������� �� �������� ����� � �������
    [SerializeField]
    private SubMenuController SubMenuController;

    public void Continue()
    {
        subMenu.SetActive(false);
        SubMenuController.SwitchCursorState(false);
        SubMenuController.SetActiveToScripts(true);
    }
}
