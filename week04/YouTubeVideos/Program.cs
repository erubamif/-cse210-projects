

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learning C#", "Erubami", 300);
        Video video2 = new Video("OOP Basics", "Freedom", 420);
        Video video3 = new Video("YouTube API Overview", "TechGuru", 600);

        // Add comments to videos
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Thanks for sharing."));

        video2.AddComment(new Comment("David", "I understand OOP better now."));
        video2.AddComment(new Comment("Eve", "Clear and simple explanation."));
        video2.AddComment(new Comment("Frank", "Loved it!"));

        video3.AddComment(new Comment("Grace", "Can't wait to try this."));
        video3.AddComment(new Comment("Heidi", "Excellent content."));
        video3.AddComment(new Comment("Ivan", "Very detailed."));

        // Put videos into a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display each video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(); // Blank line between videos
        }
    }
}