using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeGirlInteract : MonoBehaviour, IInteract
{
    [SerializeField]
    private DialogueController dialogueController;

    [SerializeField]
    private SubMenuController subMenuController;
    public void Action()
    {
        Monologue[] monologues = {
            // Monologue
            new Monologue("AAAAAAAAAAAA", "Anny"),
            new Monologue("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB", "Anny"),
            // ...
        };

        subMenuController.SetActiveToScripts(false);
        subMenuController.SwitchCursorState(true);
        dialogueController.SetMonologues(monologues);
        dialogueController.OpenDialogueMenu();   
    }
}
