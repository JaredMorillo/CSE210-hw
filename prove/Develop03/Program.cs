using System;
using System.Collections.Generic;

public class Scripture
{
    private string reference;
    private string text;
    private List<Word> words;
    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.words = InitializeWords(text);
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
        var random = new Random();
        int index = random.Next(hiddenWords.Count);
        hiddenWords[index].Hide();
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


public class Reference
{
    private string reference;
    public Reference(string reference)
    {
        this.reference = reference;
    }
    public override string ToString()
    {
        return reference;
    }
}


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
            return new string('*', word.Length);
        return word;
    }
}


public class Program
{
    public static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (!scripture.IsAllWordsHidden())
        {
            scripture.Display();
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
        }
    }
}