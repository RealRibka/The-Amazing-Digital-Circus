using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtonSubMenu : MonoBehaviour
{
    // Штука которая нажимается на эскейп менюшка эта блять
    [SerializeField]
    private GameObject subMenu;

    // хуйня которая отвечает за основные хуйни в менюшке
    [SerializeField]
    private OpenSubMenu SubMenuController;

    public void Continue()
    {
        subMenu.SetActive(false);
        SubMenuController.SwitchCursorState(false);
        SubMenuController.SetActiveToScripts(true);
    }
}
