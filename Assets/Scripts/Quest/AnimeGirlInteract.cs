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
        Choose[] choose = {
            // Choose
            new("Fuck u little poshla nahui", new Monologue[]{
                // Monologue
                new("Eh.. Why..", "Anny"),
                new("Why are you so angry...", "Anny"),
                new("Any way... Good luck...", "Anny")
            }),
            // Choose
            new("poka bluat!", new Monologue[]{
                // Monologue
                new("Bye!", "Anny")})
        };
        Monologue[] monologues = {
            // Monologue
            new("Uhm.. Hello...", "???"),
            new("Do you.. Angry?", "???"),
            new("I see... By to way my name is Anny", "Anny"),
            new("Ah... You can't talk.. Sorry.. I need to go.. Really sorry bro...", "Anny", choose),
            
        };

        subMenuController.SetActiveToScripts(false);
        subMenuController.SwitchCursorState(true);
        dialogueController.SetMonologues(monologues);
        dialogueController.OpenDialogueMenu();   
    }
}
