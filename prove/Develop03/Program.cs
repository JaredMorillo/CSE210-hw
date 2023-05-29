using System;
using System.Collections.Generic;

public class Program
{
    private Scripture scripture;
    private string userInput;
    public void Run()
    {
        while (true)
        {
            ClearConsole();
            DisplayScripture();
            PromptUser();

            if (userInput.ToLower() == "quit")
                break;

            HideRandomWords();

            if (scripture.IsFullyHidden())
                break;
        }
    }

    private void ClearConsole()
    {
        Console.Clear();
    }
    private void DisplayScripture()
    {
        Console.WriteLine(scripture.GetReference().ToString());
        Console.WriteLine(scripture.GetText());
    }
    private void PromptUser()
    {
        Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
        userInput = Console.ReadLine();
    }
    private void HideRandomWords()
    {
        List<Word> wordsToHide = scripture.GetNonHiddenWords();
        Random random = new Random();
        int index = random.Next(wordsToHide.Count);
        scripture.HideWord(wordsToHide[index]);
    }
    public static void Main()
    {
        Program program = new Program();
        program.scripture = new Scripture("John 3:16", "For God so loved the world...");
        program.Run();
    }
}


public class Scripture
{
    private Reference reference;
    private string text;
    private List<Word> hiddenWords;
    public Scripture(string reference, string text)
    {
        this.reference = new Reference(reference);
        this.text = text;
        hiddenWords = new List<Word>();
    }
    public Scripture(string reference, string text, List<Word> hiddenWords)
    {
        this.reference = new Reference(reference);
        this.text = text;
        this.hiddenWords = hiddenWords;
    }
    public Reference GetReference()
    {
        return reference;
    }
    public string GetText()
    {
        return text;
    }
    public List<Word> GetHiddenWords()
    {
        return hiddenWords;
    }
    public List<Word> GetNonHiddenWords()
    {
        List<Word> nonHiddenWords = new List<Word>();
        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            Word currentWord = new Word(word);

            if (!hiddenWords.Contains(currentWord))
                nonHiddenWords.Add(currentWord);
        }

        return nonHiddenWords;
    }
    public void HideWord(Word word)
    {
        hiddenWords.Add(word);
    }
    public bool IsFullyHidden()
    {
        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            Word currentWord = new Word(word);

            if (!hiddenWords.Contains(currentWord))
                return false;
        }

        return true;
    }
}


public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string reference)
    {
        string[] parts = reference.Split(':');
        book = parts[0];
        string[] verseParts = parts[1].Split('-');
        chapter = int.Parse(verseParts[0]);

        if (verseParts.Length == 1)
        {
            startVerse = int.Parse(verseParts[1]);
            endVerse = startVerse;
        }
        else
        {
            startVerse = int.Parse(verseParts[0]);
            endVerse = int.Parse(verseParts[1]);
        }
    }
    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        startVerse = verse;
        endVerse = verse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }
    public string GetBook()
    {
        return book;
    }
    public int GetChapter()
    {
        return chapter;
    }
    public int GetStartVerse()
    {
        return startVerse;
    }
    public int GetEndVerse()
    {
        return endVerse;
    }
    public override string ToString()
    {
        if (startVerse == endVerse)
            return $"{book} {chapter}:{startVerse}";
        else
            return $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}


public class Word
{
    private string text;
    public Word(string text)
    {
        this.text = text;
    }
    public string GetText()
    {
        return text;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Word otherWord = (Word)obj;
        return text == otherWord.text;
    }
    public override int GetHashCode()
    {
        return text.GetHashCode();
    }
}