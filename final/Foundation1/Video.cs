class Video : ICommentable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string commentText)
    {
        Comment comment = new Comment
        {
            CommenterName = commenterName,
            CommentText = commentText
        };
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}