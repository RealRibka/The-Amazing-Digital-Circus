using UnityEngine;
using TMPro;

public class Choose
{
    public string choose;
    public Monologue[] monologues;

    public Choose(string _chooses, Monologue[] _monologues)
    {
        choose = _chooses;
        monologues = _monologues;
    }

    public bool IsEmpty()
    {
        if(choose == "" && monologues[0] == new Monologue("", "") && monologues.Length == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
