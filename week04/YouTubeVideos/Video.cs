using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    // Add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Return the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}