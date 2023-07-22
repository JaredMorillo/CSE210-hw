using System;

class Program
{
    static void Main()
    {
        List<ICommentable> commentableItems = new List<ICommentable>();

        Video video1 = new Video("How to fix a House", "EngineerOfLife", 120);
        video1.AddComment("alexby11", "Great video!");
        video1.AddComment("theAmazing", "I learned a lot.");
        commentableItems.Add(video1);

        Video video2 = new Video("Another Perspective of life", "TheAnarchist", 180);
        video2.AddComment("GullieX", "Nice work!");
        video2.AddComment("ColdBoy", "Very informative.");
        commentableItems.Add(video2);

        Video video3 = new Video("C# in seconds", "ComputerGuy", 150);
        video3.AddComment("JoyAndFriends", "Thanks for sharing!");
        video3.AddComment("KevLev", "Helped me solve my problem.");
        commentableItems.Add(video3);

        foreach (var item in commentableItems)
        {
            if (item is Video video)
            {
                Console.WriteLine("Title: " + video.Title);
                Console.WriteLine("Author: " + video.Author);
                Console.WriteLine("Length: " + video.Length + " seconds");
                Console.WriteLine("Number of Comments: " + video.GetCommentCount());
                Console.WriteLine("Comments:");
                foreach (var comment in video.Comments)
                {
                    Console.WriteLine("  Commenter: " + comment.CommenterName);
                    Console.WriteLine("  Text: " + comment.CommentText);
                }
                Console.WriteLine();
            }
        }
    }
}
interface ICommentable
{
    void AddComment(string commenterName, string commentText);
    int GetCommentCount();
}