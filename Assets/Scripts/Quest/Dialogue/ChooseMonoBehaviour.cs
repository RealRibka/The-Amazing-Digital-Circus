using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public DialogueController dialogueController;

    public Choose choose;

    public void Write(string choose_name)
    {
        text.text = choose_name;
    }
    
    public void OnClick()
    {
        dialogueController.SetMonologues(choose.monologues);
        dialogueController.ClearChoises();
        dialogueController.Next();
    }
}
