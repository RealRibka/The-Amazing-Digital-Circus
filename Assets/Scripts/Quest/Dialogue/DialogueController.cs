using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private TMP_Text author;

    [SerializeField]
    private GameObject dialogueMenu;

    [SerializeField]
    private SubMenuController subMenuController;

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private LayoutGroup choosePanel;

    [SerializeField]
    private GameObject choicePrefab;

    private Monologue[] monologues;
    private int currentMonologue = 0;
    public bool isDialogueActive = false;

    public void SetMonologues(Monologue[] _monologues)
    {
        if(_monologues != null)
        {
            monologues = _monologues;
        }
        else 
        {
            Debug.Log("Trying to set null monologues");
            var monologue = new Monologue("", "");
            monologues = new Monologue[] { monologue };
        }
    }

    public Monologue[] GetMonologues()
    {
        if(monologues == null)
        {
            Debug.Log("Trying to get null monologues");
            var monologue = new Monologue("", "");
            monologues = new Monologue[] { monologue };
            return monologues;
        }
        return monologues;
    }

    public void PrintText(string text, string _author)
    {
        author.text = _author;
        this.text.text = "";
        StartCoroutine(AnimationTextPrint(text));
    }

    public void OpenDialogueMenu()
    {
        dialogueMenu.SetActive(true);
        isDialogueActive = true;
        subMenuController.canCallSubMenu = false;
        subMenuController.SetActiveToScripts(false);

        if(monologues != null)
        {
            PrintText(monologues[currentMonologue].text, monologues[currentMonologue].author);
        }
    }


    public void CloseDialogueMenu()
    {
        dialogueMenu.SetActive(false);
        isDialogueActive = false;
        subMenuController.canCallSubMenu = true;
        subMenuController.SetActiveToScripts(true);
    }

    private IEnumerator AnimationTextPrint(string text)
    {
        continueButton.enabled = false;
        for(int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(0.05f);
        }
        continueButton.enabled = true;
    }

    public void Next()
    {
        if(currentMonologue == 0)
        {
            Choice[] choices = new Choice[]
            {
                new("bobobobobobbo", new[] { new Monologue("First choice", "Anny"), new Monologue("First choiceaaaaaaaa", "Anny"), }),
                new("bububub", new[] { new Monologue("Second choice", "Anny") })
            };
            CreateChoices(choices);
        }
        if(currentMonologue < monologues.Length - 1)
        {
            currentMonologue++;
            PrintText(monologues[currentMonologue].text, monologues[currentMonologue].author);
        }
        else
        {
            currentMonologue = 0;
            CloseDialogueMenu();
        }
    }

    public void ClearChoises()
    {
        foreach(Transform child in choosePanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Function what create choices
    public void CreateChoices(Choice[] choices)
    {
        ClearChoises();
        
        if (choices.Length == 0)
        {
            // Handle the case when the choices array is empty
            return;
        }
        
        for(int i = 0; i < choices.Length; i++)
        {
            var button = Instantiate(choicePrefab, choosePanel.transform);
            button.GetComponentInChildren<TMP_Text>().text = choices[i].name;
            button.GetComponent<Button>().onClick.AddListener(Aboba);
        }
    }
    void Aboba()
    {
        SetMonologues(monogues);
        ClearChoises();
        Next();
    }
}
