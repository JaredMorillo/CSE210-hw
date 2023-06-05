using System;
using System.Collections.Generic;

class Program
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
            return new string('_', word.Length);
        return word;
    }
}

