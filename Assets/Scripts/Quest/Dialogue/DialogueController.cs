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
    private ChooseMonoBehaviour choose;
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
        bool isChooseEmpty = choose.choose.IsEmpty();
        Debug.Log(isChooseEmpty);
        if(currentMonologue < monologues.Length - 1)
        {
            if(!isChooseEmpty)
            {
                for(int i = 0; i < monologues[currentMonologue].chooses.Count(); i++)
                {
                    var chooseObject = Instantiate(choose, choosePanel.transform);
                    chooseObject.GetComponent<ChooseMonoBehaviour>().choose = monologues[currentMonologue].chooses[i];
                    chooseObject.GetComponent<ChooseMonoBehaviour>().Write(monologues[currentMonologue].chooses[i].choose);
                    chooseObject.GetComponent<ChooseMonoBehaviour>().dialogueController = this;
                }
            }
            currentMonologue++;
            PrintText(monologues[currentMonologue].text, monologues[currentMonologue].author);
        }
        else
        {
            if(!isChooseEmpty)
            {
                currentMonologue = 0;
                CloseDialogueMenu();
            }    
        }
    }

    public void ClearChoises()
    {
        foreach(Transform child in choosePanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
