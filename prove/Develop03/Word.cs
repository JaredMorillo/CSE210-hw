using System;

public class Word
{
    private string word;
    private bool isHidden;

    public Word(string word)
    {
        this.word = word;
        this.isHidden = false;
    }

    public bool IsHidden { get { return isHidden; } }

    public void Hide()
    {
        isHidden = true;
    }

    public override string ToString()
    {
        if (isHidden)
            return new string('_', word.Length);
        return word;
    }
}
