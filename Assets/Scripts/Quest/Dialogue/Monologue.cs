using UnityEditor;

public class Monologue
{
    public string author;
    public string text;
    public Choose[] chooses;

    public Monologue(string _text, string _author)
    {
        author = _author;
        text = _text;
        // make empty choose
        chooses = new Choose[0];
    }

    public Monologue(string _text, string _author, Choose[] _chooses)
    {
        author = _author;
        text = _text;
        chooses = _chooses;
    }
}
