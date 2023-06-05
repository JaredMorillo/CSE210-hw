using System;

public class Scripture
{
    private string reference;
    private string text;
    private List<Word> words;
    private Random random;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.words = InitializeWords(text);
        this.random = new Random();
    }

    public string Reference { get { return reference; } }
    public string Text { get { return text; } }

    public bool IsAllWordsHidden()
    {
        foreach (var word in words)
        {
            if (!word.IsHidden)
                return false;
        }
        return true;
    }

    public void HideRandomWord()
    {
        var hiddenWords = GetHiddenWords();

        if (hiddenWords.Count > 0)
        {
            int index = random.Next(hiddenWords.Count);
            hiddenWords[index].Hide();
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{reference}:");
        Console.WriteLine();

        foreach (var word in words)
        {
            Console.Write(word + " ");
        }

        Console.WriteLine();
    }

    private List<Word> InitializeWords(string text)
    {
        var words = new List<Word>();
        var splitText = text.Split(' ');

        foreach (var word in splitText)
        {
            words.Add(new Word(word));
        }

        return words;
    }

    private List<Word> GetHiddenWords()
    {
        var hiddenWords = new List<Word>();

        foreach (var word in words)
        {
            if (word.IsHidden)
                hiddenWords.Add(word);
        }

        return hiddenWords;
    }
}
