using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice
{
    public string name;
    public Monologue[] monologues;

    public Choice(string name, Monologue[] monologues)
    {
        this.name = name;
        this.monologues = monologues;        
    }
}
