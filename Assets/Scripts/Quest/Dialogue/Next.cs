using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NextDialogue: MonoBehaviour
{
    [SerializeField]
    DialogueController dialogueController;
    public void OnClick()
    {
        dialogueController.Next();
    }
}
